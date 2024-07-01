using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Data;
using freedom.exchange.api.Queries.Interfaces;
using freedom.exchange.transfer.models.Requests;
using freedom.exchange.transfer.models.Responses.Models;

using Dapper;

namespace freedom.exchange.api.Queries
{
    public class GetUserMessages(ISqlConnectionFactory connectionFactory) : SqlAccessor(connectionFactory), IGetUserMessages
    {
        public async Task<IEnumerable<UserMessage>> QueryAsync(GetUserMessagesRequest request)
        {
            IEnumerable<UserMessage> payload;
            using (var db = GetConnection())
            {
                var sinceWhen = await db.QuerySingleOrDefaultAsync<DateTime?>(
                    @"SELECT m.utc_sent
FROM dbo.message m
JOIN dbo.user_message um on um.message_id = m.id
WHERE um.user_id = @UserId and um.message_id = @LastMessageId;",
                    new
                    {
                        request.UserId,
                        request.LastMessageId
                    });

                payload = await db.QueryAsync<UserMessage>(
                    @"SELECT um.id AS Id, um.user_id AS SenderId, um.message_id AS MessageId, um.messaging_group_id AS GroupId, m.message AS EncryptedMessage, m.utc_sent AS UtcSent, um.utc_deleted AS UtcDeleted
FROM dbo.message m
JOIN dbo.user_message um ON um.message_id = m.id
JOIN dbo.messaging_group mg ON mg.id = um.messaging_group_id
WHERE um.user_id = @UserId
      AND um.messaging_group_id = @GroupId
      AND m.utc_deleted IS NULL
      AND um.utc_deleted IS NULL
      AND (cast(@sinceWhen as date) IS NULL OR m.utc_sent > @SinceWhen)
ORDER BY m.utc_sent DESC;",
                    new
                    {
                        request.UserId,
                        request.GroupId,
                        SinceWhen = sinceWhen
                    });
            }

            return payload;
        }
    }
}
