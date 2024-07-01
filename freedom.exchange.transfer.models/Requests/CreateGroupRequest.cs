using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace freedom.exchange.transfer.models.Requests
{
    public class CreateGroupRequest
    {
        [FromBody]
        public IEnumerable<string> UserIds { get; set; }

        [FromBody]
        public string Name { get; set; }
    }
}
