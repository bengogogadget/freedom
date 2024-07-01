using freedom.exchange.transfer.models.Responses.Models;

using System.Collections.Generic;

namespace freedom.exchange.transfer.models.Responses
{
    public class GetUserMessagesResponse
    {
        public IEnumerable<UserMessage> Messages { get; set; }
    }
}
