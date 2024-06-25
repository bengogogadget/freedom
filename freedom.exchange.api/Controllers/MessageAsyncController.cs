using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Dto;
using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/message")]
    public class MessageAsyncController(ICreateMessage sendMessages, IUpdateMessage updateMessage) : FeController
    {
        [HttpPost]
        public async Task<CreateUserMessageResponse> Post([FromBody] CreateUserMessageRequest request)
        {
            return new CreateUserMessageResponse
            {
                MessageId = await sendMessages.ExecuteAsync(request)
            };
        }

        [HttpPut]
        public async Task<UpdateMessageResponse> Put([FromBody] UpdateMessageRequest request)
        {
            await updateMessage.ExecuteAsync(request);
            return new UpdateMessageResponse();
        }
    }
}
