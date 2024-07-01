using freedom.exchange.transfer.models.Requests;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateUser
    {
        Task<string> ExecuteAsync(CreateUserRequest request);
    }
}