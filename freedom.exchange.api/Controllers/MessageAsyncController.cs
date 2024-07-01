using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses;

using Microsoft.AspNetCore.Mvc;

namespace freedom.exchange.api.Controllers
{
    [Route("api/message")]
    public class MessageAsyncController(ICreateMessage sendMessages, IUpdateMessage updateMessage) : FeController
    {
        [HttpPost]
        public async Task<CreateMessageResponse> Post([FromBody] CreateMessageRequest request)
        {
            return new CreateMessageResponse
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
