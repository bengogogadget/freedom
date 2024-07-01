using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.transfer.models.Requests;

using Dapper;

namespace freedom.exchange.api.Commands
{
    public class UpdateUserMessage(ISqlConnectionFactory sqlConnectionFactory) : IUpdateUserMessage
    {
        public async Task<bool> ExecuteAsync(UpdateUserMessageRequest request)
        {
            using (var db = sqlConnectionFactory.Open())
            {
                return await db.ExecuteAsync(
                    @"UPDATE um SET
utc_read = @UtcRead,
utc_deleted = @UtcDeleted
FROM dbo.user_message um
JOIN dbo.message m ON m.id = um.message_id
WHERE m.id = @Id AND um.user_id = @UserId;",
                    new
                    {
                        request.MessageId,
                        request.UserId,
                        request.UtcRead,
                        request.UtcDeleted
                    }) > 0;
            }
        }
    }
}
