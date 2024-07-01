using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.transfer.models.Requests;

using Dapper;

namespace freedom.exchange.api.Commands
{
    public class UpdateMessage(ISqlConnectionFactory sqlConnectionFactory) : IUpdateMessage
    {
        public async Task<bool> ExecuteAsync(UpdateMessageRequest request)
        {
            using (var db = sqlConnectionFactory.Open())
            {
                return await db.ExecuteAsync(
                    @"UPDATE dbo.message SET
message = @EncryptedMessage,
utc_deleted = @UtcDeletedForAll
WHERE id = @MessageId;",
                    new
                    {
                        request.MessageId,
                        request.EncryptedMessage,
                        request.UtcDeletedForAll
                    }) > 0;
            }
        }
    }
}
