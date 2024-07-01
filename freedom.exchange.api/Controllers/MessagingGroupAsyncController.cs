using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/group")]
    public class MessagingGroupAsyncController(ICreateMessagingGroup createMessagingGroup, IGetMessagingGroupUsers getMessagingGroupUsers) : FeController
    {
        [HttpPost]
        public async Task<CreateMessagingGroupResponse> Post([FromBody] CreateGroupRequest request)
        {
            return new CreateMessagingGroupResponse
            {
                GroupId = await createMessagingGroup.ExecuteAsync(request)
            };
        }

        

        [HttpGet]
        public async Task<GetMessagingGroupUsersResponse> Get(GetMessagingGroupUsersRequest request)
        {
            return new GetMessagingGroupUsersResponse
            {
                Users = await getMessagingGroupUsers.QueryAsync(request)
            };
        }
    }
}
