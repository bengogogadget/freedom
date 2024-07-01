using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.transfer.models.Requests
{
    public class CreateMessageRequest
    {
        [FromBody]
        public string EncryptedMessage { get; set; }

        [FromBody]
        public string SenderId { get; set; }

        [FromBody]
        public string GroupId { get; set; }
    }
}
