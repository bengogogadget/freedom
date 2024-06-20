using freedom.exchange.api.Dto;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface ICreateMessagingGroup
    {
        string Execute(CreateMessagingGroupRequest request);
    }
}
