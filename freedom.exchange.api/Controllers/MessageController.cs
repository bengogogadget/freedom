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
    public class MessageController(ICreateMessage sendMessages, IGetUserMessages getUserMessage) : FeController
    {
        [HttpPost]
        public CreateUserMessageResponse Post([FromBody] CreateUserMessageRequest request)
        {
            return new CreateUserMessageResponse
            {
                MessageId = sendMessages.Execute(request)
            };
        }

        [HttpGet]
        public GetUserMessagesResponse Get(GetUserMessagesRequest request)
        {
            return new GetUserMessagesResponse
            {
                Messages = getUserMessage.Query(request) ?? Enumerable.Empty<UserMessage>()
            };
        }
    }
}
