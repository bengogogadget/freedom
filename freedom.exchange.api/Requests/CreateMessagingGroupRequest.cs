namespace freedom.exchange.api.Dto
{
    public class CreateMessagingGroupRequest
    {
        public IEnumerable<string> UserIds { get; set; }
        
        public string Name { get; set; }
    }
}
