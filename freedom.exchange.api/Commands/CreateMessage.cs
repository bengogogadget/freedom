using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Data;
using freedom.exchange.api.Dto;

using Dapper;

namespace freedom.exchange.api.Commands
{
    public class CreateMessage(ISqlConnectionFactory connectionFactory, IDateTimeProvider dateTimeProvider, IUuidGenerator uuidGenerator) : SqlAccessor(connectionFactory), ICreateMessage
    {
        public async Task<string> ExecuteAsync(CreateUserMessageRequest request)
        {
            string messageId = uuidGenerator.GenerateUuid();

            int result;
            using (var db = GetConnection())
            {
                var userIdsAsync = db.QueryAsync<string>(
                    @"SELECT user_id
FROM dbo.messaging_group_user
WHERE messaging_group_id = @MessagingGroupId;",
                    new
                    {
                        request.MessagingGroupId
                    });

                result = await db.ExecuteAsync(
                    @"INSERT INTO dbo.message ( id, message, utc_sent, sender_id, messaging_group_id )
VALUES ( @Id, @EncryptedMessage, @UtcSent, @SenderId, @MessagingGroupId );",
                    new {
                        Id = messageId,
                        request.EncryptedMessage,
                        UtcSent = dateTimeProvider.UtcNow,
                        request.SenderId,
                        request.MessagingGroupId
                    });

                var executions = new List<Task<int>>();
                foreach (var userId in userIdsAsync.Result)
                {
                    executions.Add(db.ExecuteAsync(
                        @"INSERT INTO dbo.user_message ( id, user_id, message_id, messaging_group_id )
VALUES ( @Id, @UserId, @MessageId, @MessagingGroupId );",
                        new
                        {
                            Id = uuidGenerator.GenerateUuid(),
                            UserId = userId,
                            MessageId = messageId,
                            request.MessagingGroupId
                        }));
                }

                Task.WaitAll(executions.ToArray());
            }

            return messageId;
        }
    }
}
