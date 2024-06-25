using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Requests
{
    public class UpdateUserMessageRequest
    {
        [FromBody]
        public string MessageId { get; set; }

        [FromBody]
        public string UserId { get; set; }

        [FromBody]
        public DateTime? UtcRead { get; set; }

        [FromBody]
        public DateTime? UtcDeleted { get; set; }
    }
}
