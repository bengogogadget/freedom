using freedom.exchange.transfer.models.Responses.Models;

using System.Collections.Generic;

namespace freedom.exchange.transfer.models.Responses
{
    public class GetMessagingGroupUsersResponse
    {
        public IDictionary<string, IEnumerable<GroupUser>> Users { get; set; }
    }
}
