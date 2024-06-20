using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("/api/user_messaging_group")]
    public class UserMessagingGroupController(IGetUserMessagingGroups getUserMessagingGroups) : FeController
    {
        [HttpGet]
        public GetUserMessagingGroupsResponse Get(GetUserMessagingGroupsRequest request)
        {
            return new GetUserMessagingGroupsResponse
            {
                MessagingGroups = getUserMessagingGroups.Execute(request)
            };
        }
    }
}
