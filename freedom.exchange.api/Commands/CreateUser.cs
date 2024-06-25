using bengogogadget.core.Infrastructure.Interfaces;
using freedom.exchange.api.Commands.Interfaces;
using freedom.exchange.api.Data;
using freedom.exchange.api.Dto;

using Dapper;

namespace freedom.exchange.api.Commands
{
    public class CreateUser(ISqlConnectionFactory connectionFactory, IDateTimeProvider dateTimeProvider, IUuidGenerator uuidGenerator) : SqlAccessor(connectionFactory), ICreateUser
    {
        public async Task<string> ExecuteAsync(CreateUserRequest request)
        {
            var id = uuidGenerator.GenerateUuid();
            int result;
            using (var db = GetConnection())
            {
                result = await db.ExecuteAsync(
                    @"INSERT INTO dbo.user ( id, name, utc_created, phone_number, email, date_of_birth )
VALUES ( @Id, @Name, @UtcCreated, @PhoneNumber, @Email, @DateOfBirth );",
                    new
                    {
                        Id = id,
                        request.Name,
                        UtcCreated = dateTimeProvider.UtcNow,
                        request.PhoneNumber,
                        request.Email,
                        request.DateOfBirth
                    });
            }

            return id;
        }
    }
}
