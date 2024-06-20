using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Requests
{
    public class GetUserMessagingGroupsRequest
    {
        [FromQuery]
        public string UserId { get; set; }
    }
}
