using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Data;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.api.Requests;

using Dapper;
using freedom.exchange.api.Responses.Models;

namespace freedom.exchange.api.Queries
{
    public class GetUserMessages(ISqlConnectionFactory connectionFactory) : SqlAccessor(connectionFactory), IGetUserMessages
    {
        public IEnumerable<UserMessage> Query(GetUserMessagesRequest request)
        {
            IEnumerable<UserMessage> payload;
            using (var db = GetConnection())
            {
                var sinceWhen = db.QuerySingleOrDefault<DateTime?>(
                    @"select m.utc_sent
from dbo.message m
join dbo.user_message um on um.message_id = m.id
where um.user_id = @UserId and um.message_id = @LastMessageId;",
                    new
                    {
                        request.UserId,
                        request.LastMessageId
                    });

                payload = db.Query<UserMessage>(
                    @"SELECT um.id AS Id, um.user_id AS SenderId, um.message_id AS MessageId, um.messaging_group_id AS MessagingGroupId, m.message AS EncryptedMessage, m.utc_sent AS UtcSent, um.utc_deleted AS UtcDeleted
FROM dbo.message m
JOIN dbo.user_message um ON um.message_id = m.id
JOIN dbo.messaging_group mg ON mg.id = um.messaging_group_id
WHERE um.user_id = @UserId AND um.messaging_group_id = @MessagingGroupId AND (cast(@sinceWhen as date) IS NULL OR m.utc_sent > @SinceWhen)
ORDER BY m.utc_sent DESC;",
                    new
                    {
                        request.UserId,
                        request.MessagingGroupId,
                        SinceWhen = sinceWhen
                    });
            }

            return payload;
        }
    }
}
