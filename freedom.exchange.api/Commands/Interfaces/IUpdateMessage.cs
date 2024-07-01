using freedom.exchange.transfer.models.Requests;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface IUpdateMessage
    {
        Task<bool> ExecuteAsync(UpdateMessageRequest request);
    }
}
