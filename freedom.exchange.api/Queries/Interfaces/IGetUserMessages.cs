using freedom.exchange.api.Requests;
using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Queries.Interfaces
{
    public interface IGetUserMessages
    {
        Task<IEnumerable<UserMessage>> QueryAsync(GetUserMessagesRequest request);
    }
}