using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Dto;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/message/group")]
    public class MessagingGroupAsyncController(ICreateMessagingGroup createMessagingGroup, IGetMessagingGroupUsers getMessagingGroupUsers) : FeController
    {
        [HttpPost]
        public async Task<CreateMessagingGroupResponse> Post([FromBody] CreateMessagingGroupRequest request)
        {
            return new CreateMessagingGroupResponse
            {
                MessagingGroupId = await createMessagingGroup.ExecuteAsync(request)
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
