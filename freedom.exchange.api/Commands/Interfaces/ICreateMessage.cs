using freedom.exchange.transfer.models.Requests;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateMessage
    {
        Task<string> ExecuteAsync(CreateMessageRequest request);
    }
}