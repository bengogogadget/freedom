using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses.Models;

using Dapper;

namespace freedom.exchange.api.Queries
{
    public class GetMessageGroupUsers(ISqlConnectionFactory sqlConnectionFactory) : IGetMessagingGroupUsers
    {
        public async Task<IDictionary<string, IEnumerable<MessagingGroupUser>>> QueryAsync(GetMessagingGroupUsersRequest request)
        {
            IEnumerable<MessagingGroupUser> users;
            using (var db = sqlConnectionFactory.Open())
            {
                users = await db.QueryAsync<MessagingGroupUser>(
                    @"SELECT mgu.messaging_group_id AS MessagingGroupId, u.id AS Id, u.name AS Name
FROM dbo.user u
JOIN dbo.messaging_group_user mgu ON mgu.user_id = u.id
WHERE mgu.messaging_group_id = ANY(@MessagingGroupIds);",
                    new
                    {
                        request.MessagingGroupIds
                    });
            }

            return users
                    .GroupBy(x => x.MessagingGroupId)
                    .ToDictionary(g => g.Key, g => g.AsEnumerable());
        }
    }
}
