using Dapper;
using Product.Application.Common.DataReadingModels.Supplayeres;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Product.Infrastructure.Persistence.repositries.Supplayersrepositries
{
    public class ProductSupplayerRepository : IProductSupplayerRepository
    {
        private readonly IDbSettings _dbSettings;

        public ProductSupplayerRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public async Task<IEnumerable<ProductSupplayerReadForm>> GetByPhoneAsync(Guid? productId, string phone)
        {
            var procName = "SupplayersData.GetProductSupplayers";

            var parameters = new { productId, phone };

            using var conn =_dbSettings.CreateConnection();
            return await conn.QueryAsync<ProductSupplayerReadForm>(
                sql: procName,
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

        }
    }
}
