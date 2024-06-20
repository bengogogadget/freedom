namespace freedom.exchange.api.Responses.Models
{
    public class UserMessage
    {
        public string Id { get; set; }

        public string MessageId { get; set; }

        public string EncryptedMessage { get; set; }

        public DateTime UtcSent { get; set; }

        public string SenderId { get; set; }

        public string MessagingGroupId { get; set; }

        public DateTime? UtcDeleted { get; set; }
    }
}
