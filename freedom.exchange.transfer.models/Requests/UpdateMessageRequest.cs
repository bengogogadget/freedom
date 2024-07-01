using Microsoft.AspNetCore.Mvc;
using System;

namespace freedom.exchange.transfer.models.Requests
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
