using Microsoft.Data.SqlClient;
using System.Data;

namespace Product.Infrastructure.Persistence.DbSettings
{
    public class ReadingDbSettings : IDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }

}