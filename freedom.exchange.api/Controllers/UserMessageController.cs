using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;
using freedom.exchange.api.Responses.Models;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/user/message")]
    public class UserMessageController(IGetUserMessages getUserMessage, IUpdateUserMessage updateUserMessage) : FeController
    {
        [HttpGet]
        public async Task<GetUserMessagesResponse> Get(GetUserMessagesRequest request)
        {
            return new GetUserMessagesResponse
            {
                Messages = await getUserMessage.QueryAsync(request) ?? Enumerable.Empty<UserMessage>()
            };
        }

        [HttpPut]
        public async Task<UpdateMessageResponse> Put(UpdateUserMessageRequest request)
        {
            await updateUserMessage.ExecuteAsync(request);
            return new UpdateMessageResponse();
        }
    }
}
