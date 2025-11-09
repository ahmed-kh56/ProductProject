using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Product.Application.Common.DataReadingModels.ProductsData;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;
using Product.Domain.Products;
using Product.Infrastructure.Persistence.DbSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.repositries.Productrepositries
{
    internal class ProductReadRepository : IProductReadRepository
    {

        private readonly IDbSettings _dbSettings;

        public ProductReadRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var procName = "ProductsData.CheckProductExists";
            var parameters = new { Id = id };
            using var connection = new SqlConnection(_dbSettings.ConnectionString);

            var result = await connection.QuerySingleAsync<int>(
                procName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return result == 1;
        }

        public async Task<IEnumerable<ProductItem>> GetAllAsync()
        {
            var command = "SELECT * FROM Products";
            using var connection = _dbSettings.CreateConnection();
            return await connection.QueryAsync<ProductItem>(command);

        }

        public async Task<ProductItem?> GetByIdAsync(Guid ProductId)
        {
            var sql = "[ProductsData].[ProductItem_GetById]";
            var parameters = new { ProductId };
            var conn = _dbSettings.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<ProductItem>(
                sql: sql,
                param: parameters);
        }

        public async Task<ProductDetailsReadModel?> GetDataModelAsync(Guid ProductId)
        {
            var command = "ProductsData.[GetProductDetailsById]";
            var paramaters = new { ProductId };
            using var conn = _dbSettings.CreateConnection();

            return await conn.QueryFirstOrDefaultAsync<ProductDetailsReadModel>(
                sql: command,
                param: paramaters);
        }


    }
}
