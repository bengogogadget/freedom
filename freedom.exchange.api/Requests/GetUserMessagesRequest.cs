using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Requests
{
    public class GetUserMessagesRequest
    {
        [FromQuery]
        public string UserId { get; set; }

        [FromQuery]
        public string MessagingGroupId { get; set; }

        [FromQuery]
        public string? LastMessageId { get; set; }
    }
}
