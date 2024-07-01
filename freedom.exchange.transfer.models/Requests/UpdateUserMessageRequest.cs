using Microsoft.AspNetCore.Mvc;
using System;

namespace freedom.exchange.transfer.models.Requests
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
