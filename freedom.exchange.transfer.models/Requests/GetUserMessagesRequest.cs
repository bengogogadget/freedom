using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.transfer.models.Requests
{
    public class GetUserMessagesRequest
    {
        [FromQuery]
        public string UserId { get; set; }

        [FromQuery]
        public string GroupId { get; set; }

        [FromQuery]
        public string? LastMessageId { get; set; }
    }
}
