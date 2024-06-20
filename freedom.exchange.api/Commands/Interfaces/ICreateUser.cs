using freedom.exchange.api.Dto;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateUser
    {
        Task<string> ExecuteAsync(CreateUserRequest request);
    }
}