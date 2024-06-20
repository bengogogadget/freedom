namespace freedom.exchange.api.Dto
{
    public class CreateUserMessageRequest
    {
        public string EncryptedMessage { get; set; }
        
        public string SenderId { get; set; }
        
        public string MessagingGroupId { get; set; }
    }
}
