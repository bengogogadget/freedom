using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Responses
{
    public class GetMessagingGroupUsersResponse
    {
        public IDictionary<string, IEnumerable<MessagingGroupUser>> Users { get; set; }
    }
}
