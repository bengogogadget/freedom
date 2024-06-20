using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Requests
{
    public class GetMessagingGroupUsersRequest
    {
        [FromQuery]
        public IEnumerable<string> MessagingGroupIds { get; set; }
    }
}
