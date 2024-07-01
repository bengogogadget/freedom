using freedom.exchange.transfer.models.Requests;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateMessagingGroup
    {
        Task<string> ExecuteAsync(CreateGroupRequest request);
    }
}
