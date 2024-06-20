using freedom.exchange.api.Dto;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateUser
    {
        string Execute(CreateUserRequest request);
    }
}