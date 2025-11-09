using Dapper;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;
using Product.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Product.Infrastructure.Persistence.repositries.Barcderepositries
{
    internal class PriceReadRepository : IPriceReadRepository
    {

        private readonly IDbSettings _dbSettings;

        public PriceReadRepository(IDbSettings dbSettings)
        {
            this._dbSettings = dbSettings;
        }

        public async Task<IEnumerable<PriceAccordingToBranch>> GetAllPricesAsync(
            string? code = null,
            Guid? productId = null)
        {
            const string sql = "PricingData.GetAllPrices";

            var parameters = new
            {
                Barcode = code,
                ProductId = productId
            };

            using var connection = _dbSettings.CreateConnection();

            return await connection.QueryAsync<PriceAccordingToBranch>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<PriceAccordingToBranch?> GetByBarcodeAndBranchAsync(string code, int branchId)
        {

            var sql = "PricingData.GetAllPrices";
            var parameters = new { Barcode = code, BranchId = branchId };

            using var connection = _dbSettings.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<PriceAccordingToBranch>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
