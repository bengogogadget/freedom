using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.transfer.models.Requests
{
    public class GetUserGroupsRequest
    {
        [FromQuery]
        public string UserId { get; set; }
    }
}
