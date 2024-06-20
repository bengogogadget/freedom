using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Dto;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;
using freedom.exchange.api.Responses.Models;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/message")]
    public class MessageAsyncController(ICreateMessage sendMessages, IGetUserMessages getUserMessage) : FeController
    {
        [HttpPost]
        public async Task<CreateUserMessageResponse> Post([FromBody] CreateUserMessageRequest request)
        {
            return new CreateUserMessageResponse
            {
                MessageId = await sendMessages.ExecuteAsync(request)
            };
        }

        [HttpGet]
        public async Task<GetUserMessagesResponse> Get(GetUserMessagesRequest request)
        {
            return new GetUserMessagesResponse
            {
                Messages = await getUserMessage.QueryAsync(request) ?? Enumerable.Empty<UserMessage>()
            };
        }
    }
}
