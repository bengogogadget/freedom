using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("/api/user/group")]
    public class UserGroupAsyncController(IGetUserGroups getUserGroups) : FeController
    {
        [HttpGet]
        public async Task<GetUserGroupsResponse> Get(GetUserGroupsRequest request)
        {
            return new GetUserGroupsResponse
            {
                Groups = await getUserGroups.ExecuteAsync(request)
            };
        }
    }
}
