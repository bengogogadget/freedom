using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses.Models;

using Dapper;

namespace freedom.exchange.api.Queries
{
    public class GetMessageGroupUsers(ISqlConnectionFactory sqlConnectionFactory) : IGetMessagingGroupUsers
    {
        public IDictionary<string, IEnumerable<MessagingGroupUser>> Query(GetMessagingGroupUsersRequest request)
        {
            using (var db = sqlConnectionFactory.Open())
            {
                return db.Query<MessagingGroupUser>(
                    @"SELECT mgu.messaging_group_id AS MessagingGroupId, u.id AS Id, u.name AS Name
FROM dbo.user u
JOIN dbo.messaging_group_user mgu ON mgu.user_id = u.id
WHERE mgu.messaging_group_id = ANY(@MessagingGroupIds);",
                    new
                    {
                        request.MessagingGroupIds
                    })
                    .GroupBy(x => x.MessagingGroupId)
                    .ToDictionary(g => g.Key, g => g.AsEnumerable());
            }
        }
    }
}
