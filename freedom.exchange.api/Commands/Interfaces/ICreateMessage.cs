using freedom.exchange.api.Dto;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateMessage
    {
        string Execute(CreateUserMessageRequest request);
    }
}