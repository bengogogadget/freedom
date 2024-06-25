using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("/api/user/message/group")]
    public class UserMessagingGroupAsyncController(IGetUserMessagingGroups getUserMessagingGroups) : FeController
    {
        [HttpGet]
        public async Task<GetUserMessagingGroupsResponse> Get(GetUserMessagingGroupsRequest request)
        {
            return new GetUserMessagingGroupsResponse
            {
                MessagingGroups = await getUserMessagingGroups.ExecuteAsync(request)
            };
        }
    }
}
