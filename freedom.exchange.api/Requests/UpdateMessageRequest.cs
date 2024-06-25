using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Requests
{
    public class UpdateMessageRequest
    {
        [FromBody]
        public string MessageId { get; set; }

        [FromBody]
        public string? EncryptedMessage { get; set; }

        [FromBody]
        public DateTime? UtcDeletedForAll { get; set; }
    }
}
