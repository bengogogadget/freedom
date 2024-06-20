using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Responses
{
    public class GetUserMessagingGroupsResponse
    {
        public IEnumerable<UserMessageGroup> MessagingGroups { get; set; }
    }
}
