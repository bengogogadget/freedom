using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Dto
{
    public class CreateUserMessageRequest
    {
        [FromBody]
        public string EncryptedMessage { get; set; }

        [FromBody]
        public string SenderId { get; set; }

        [FromBody]
        public string MessagingGroupId { get; set; }
    }
}
