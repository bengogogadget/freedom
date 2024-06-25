using freedom.exchange.api.Requests;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface IUpdateMessage
    {
        Task<bool> ExecuteAsync(UpdateMessageRequest request);
    }
}
