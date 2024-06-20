using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Queries.Interfaces
{
    public interface IGetUserMessagingGroups
    {
        public IEnumerable<UserMessageGroup> Execute(GetUserMessagingGroupsRequest request);
    }
}
