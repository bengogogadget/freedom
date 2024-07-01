using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses.Models;

namespace freedom.exchange.api.Queries.Interfaces
{
    public interface IGetMessagingGroupUsers
    {
        public Task<IDictionary<string, IEnumerable<GroupUser>>> QueryAsync(GetMessagingGroupUsersRequest request);
    }
}
