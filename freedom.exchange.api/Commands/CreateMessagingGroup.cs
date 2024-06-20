using bengogogadget.core.Extensions;
using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Dto;

using Dapper;

namespace freedom.exchange.api.Commands
{
    public class CreateMessagingGroup(ISqlConnectionFactory sqlConnectionFactory, IUuidGenerator uuidGenerator, IDateTimeProvider dateTimeProvider) : ICreateMessagingGroup
    {
        public string Execute(CreateMessagingGroupRequest request)
        {
            string newMessagingGroupId = uuidGenerator.GenerateUuid();
            string hash = request.UserIds.ToBase64Hash();
            using (var db = sqlConnectionFactory.Open())
            {
                var existing = db.QuerySingleOrDefault(
                    @"SELECT id AS Id FROM dbo.messaging_group WHERE hash = @hash",
                    new
                    {
                        hash
                    });

                if (existing != null)
                {
                    return existing.Id;
                }

                db.Execute(
                    @"INSERT INTO dbo.messaging_group ( id, name, hash ) VALUES ( @Id, @Name, @Hash);",
                    new
                    {
                        Id = newMessagingGroupId,
                        request.Name,
                        Hash = hash
                    });

                foreach (var userId in request.UserIds)
                {
                    db.Execute(
                        @"INSERT INTO dbo.messaging_group_user ( id, messaging_group_id, user_id, utc_added ) VALUES ( @Id, @MessagingGroupId, @UserId, @UtcAdded );",
                        new
                        {
                            Id = uuidGenerator.GenerateUuid(),
                            MessagingGroupId = newMessagingGroupId,
                            UserId = userId,
                            UtcAdded = dateTimeProvider.UtcNow
                        });
                }

                return newMessagingGroupId;
            }
        }
    }
}
