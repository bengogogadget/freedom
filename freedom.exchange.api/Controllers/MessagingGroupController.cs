using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Dto;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/messaging_group")]
    public class MessagingGroupController(ICreateMessagingGroup createMessagingGroup, IGetMessagingGroupUsers getMessagingGroupUsers) : FeController
    {
        [HttpPost]
        public CreateMessagingGroupResponse Post([FromBody] CreateMessagingGroupRequest request)
        {
            return new CreateMessagingGroupResponse
            {
                MessagingGroupId = createMessagingGroup.Execute(request)
            };
        }

        

        [HttpGet]
        public GetMessagingGroupUsersResponse Get(GetMessagingGroupUsersRequest request)
        {
            return new GetMessagingGroupUsersResponse
            {
                Users = getMessagingGroupUsers.Query(request)
            };
        }
    }
}
