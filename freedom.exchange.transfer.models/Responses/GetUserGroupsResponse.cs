using freedom.exchange.transfer.models.Responses.Models;

using System.Collections.Generic;

namespace freedom.exchange.transfer.models.Responses
{
    public class GetUserGroupsResponse
    {
        public IEnumerable<UserGroup> Groups { get; set; }
    }
}
