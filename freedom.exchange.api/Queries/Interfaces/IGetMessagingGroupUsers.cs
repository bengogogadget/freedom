using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Queries.Interfaces
{
    public interface IGetMessagingGroupUsers
    {
        public Task<IDictionary<string, IEnumerable<MessagingGroupUser>>> QueryAsync(GetMessagingGroupUsersRequest request);
    }
}
