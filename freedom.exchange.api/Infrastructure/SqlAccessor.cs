using bengogogadget.core.Infrastructure.Interfaces;

using System.Data;

namespace freedom.exchange.api.Data
{
    public class SqlAccessor(ISqlConnectionFactory connectionFactory)
    {
        public ISqlConnectionFactory ConnectionFactory { get; } = connectionFactory;

        protected IDbConnection GetConnection()
        {
            return ConnectionFactory.Open();
        }
    }
}
