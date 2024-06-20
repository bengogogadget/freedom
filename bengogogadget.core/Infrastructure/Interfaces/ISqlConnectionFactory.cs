using System.Data;

namespace bengogogadget.core.Infrastructure.Interfaces
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Open();
    }
}
