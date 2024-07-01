using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace freedom.exchange.transfer.models.Requests
{
    public class GetMessagingGroupUsersRequest
    {
        [FromQuery]
        public IEnumerable<string> GroupIds { get; set; }
    }
}
