using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses.Models;

using Dapper;

namespace freedom.exchange.api.Queries
{
    public class GetUserGroups(ISqlConnectionFactory sqlConnectionFactory) : IGetUserGroups
    {
        public async Task<IEnumerable<UserGroup>> ExecuteAsync(GetUserGroupsRequest request)
        {
            using (var db = sqlConnectionFactory.Open())
            {
                return await db.QueryAsync<UserGroup>(
                    @"SELECT messaging_group_id AS Id, mg.name AS Name, mg.hash AS Hash, utc_removed AS UtcRemoved
FROM dbo.messaging_group_user mgu
JOIN dbo.messaging_group mg ON mg.id = mgu.messaging_group_id
WHERE mgu.user_id = @UserId
      AND mgu.utc_removed IS NULL;",
                    new
                    {
                        request.UserId
                    });
            }
        }
    }
}
