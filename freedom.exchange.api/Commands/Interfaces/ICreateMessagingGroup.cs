using freedom.exchange.api.Dto;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateMessagingGroup
    {
        Task<string> ExecuteAsync(CreateMessagingGroupRequest request);
    }
}
