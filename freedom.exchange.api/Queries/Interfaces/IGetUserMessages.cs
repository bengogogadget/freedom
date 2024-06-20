using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Queries.Interfaces
{
    public interface IGetUserMessages
    {
        IEnumerable<UserMessage> Query(GetUserMessagesRequest request);
    }
}