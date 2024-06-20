using bengogogadget.core.Infrastructure.Interfaces;

using System.Data;
using Npgsql;

namespace freedom.exchange.api.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public IDbConnection Open()
        {
            var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=MJBjy8bfFYXgLaNp;Database=freedom.exchange");

            connection.Open();

            return connection;
        }
    }
}
