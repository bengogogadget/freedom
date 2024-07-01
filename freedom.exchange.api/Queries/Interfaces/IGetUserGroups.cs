using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses.Models;

namespace freedom.exchange.api.Queries.Interfaces
{
    public interface IGetUserGroups
    {
        public Task<IEnumerable<UserGroup>> ExecuteAsync(GetUserGroupsRequest request);
    }
}
