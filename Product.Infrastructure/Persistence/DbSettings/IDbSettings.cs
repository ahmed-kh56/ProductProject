using System.Data;

namespace Product.Infrastructure.Persistence.DbSettings
{
    public interface IDbSettings
    {
        public string ConnectionString { get; }

        IDbConnection CreateConnection();
    }
}
