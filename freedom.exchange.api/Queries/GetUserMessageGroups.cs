using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;

using Dapper;
using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Queries
{
    public class GetUserMessageGroups(ISqlConnectionFactory sqlConnectionFactory) : IGetUserMessagingGroups
    {
        public async Task<IEnumerable<UserMessageGroup>> ExecuteAsync(GetUserMessagingGroupsRequest request)
        {
            using (var db = sqlConnectionFactory.Open())
            {
                return await db.QueryAsync<UserMessageGroup>(
                    @"SELECT messaging_group_id AS Id, mg.name AS Name, mg.hash AS Hash, utc_removed AS UtcRemoved
FROM dbo.messaging_group_user mgu
JOIN dbo.messaging_group mg ON mg.id = mgu.messaging_group_id
WHERE user_id = @UserId
--Not filtering out groups user is removed from at this point",
                    new
                    {
                        request.UserId
                    });
            }
        }
    }
}
