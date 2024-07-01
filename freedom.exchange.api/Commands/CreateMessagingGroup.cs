using bengogogadget.core.Extensions;
using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.transfer.models.Requests;

using Dapper;

namespace freedom.exchange.api.Commands
{
    public class CreateMessagingGroup(ISqlConnectionFactory sqlConnectionFactory, IUuidGenerator uuidGenerator, IDateTimeProvider dateTimeProvider) : ICreateMessagingGroup
    {
        public async Task<string> ExecuteAsync(CreateGroupRequest request)
        {
            string newGroupId = uuidGenerator.GenerateUuid();
            string hash = request.UserIds.ToBase64Hash();
            using (var db = sqlConnectionFactory.Open())
            {
                var existing = await db.QuerySingleOrDefaultAsync(
                    @"SELECT id AS Id FROM dbo.messaging_group WHERE hash = @hash;",
                    new
                    {
                        hash
                    });

                if (existing != null)
                {
                    return existing.Id;
                }

                await db.ExecuteAsync(
                    @"INSERT INTO dbo.messaging_group ( id, name, hash )
VALUES ( @Id, @Name, @Hash);",
                    new
                    {
                        Id = newGroupId,
                        request.Name,
                        Hash = hash
                    });

                var executions = new List<Task<int>>();
                foreach (var userId in request.UserIds)
                {
                    executions.Add(db.ExecuteAsync(
                        @"INSERT INTO dbo.messaging_group_user ( id, messaging_group_id, user_id, utc_added )
VALUES ( @Id, @GroupId, @UserId, @UtcAdded );",
                        new
                        {
                            Id = uuidGenerator.GenerateUuid(),
                            GroupId = newGroupId,
                            UserId = userId,
                            UtcAdded = dateTimeProvider.UtcNow
                        }));
                }

                Task.WaitAll(executions.ToArray());
            }

            return newGroupId;
        }
    }
}
