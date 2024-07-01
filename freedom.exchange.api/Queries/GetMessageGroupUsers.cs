using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses.Models;

using Dapper;

namespace freedom.exchange.api.Queries
{
    public class GetMessageGroupUsers(ISqlConnectionFactory sqlConnectionFactory) : IGetMessagingGroupUsers
    {
        public async Task<IDictionary<string, IEnumerable<GroupUser>>> QueryAsync(GetMessagingGroupUsersRequest request)
        {
            IEnumerable<GroupUser> users;
            using (var db = sqlConnectionFactory.Open())
            {
                users = await db.QueryAsync<GroupUser>(
                    @"SELECT mgu.messaging_group_id AS MessagingGroupId, u.id AS Id, u.name AS Name
FROM dbo.user u
JOIN dbo.messaging_group_user mgu ON mgu.user_id = u.id
WHERE mgu.messaging_group_id = ANY(@GroupIds);",
                    new
                    {
                        request.GroupIds
                    });
            }

            return users
                    .GroupBy(x => x.GroupId)
                    .ToDictionary(g => g.Key, g => g.AsEnumerable());
        }
    }
}
