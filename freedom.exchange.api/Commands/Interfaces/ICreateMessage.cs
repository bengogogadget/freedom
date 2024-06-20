using freedom.exchange.api.Dto;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateMessage
    {
        Task<string> ExecuteAsync(CreateUserMessageRequest request);
    }
}