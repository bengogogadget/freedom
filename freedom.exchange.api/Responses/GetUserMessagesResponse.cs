using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Responses
{
    public class GetUserMessagesResponse
    {
        public IEnumerable<UserMessage> Messages { get; set; }
    }
}
