using Dapper;
using Product.Application.Common.DataReadingModels.Barcodes;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Product.Infrastructure.Persistence.repositries.Barcderepositries
{
    internal class BarcodeReadRepository : IBarcodeReadRepository
    {
        private readonly IDbSettings dbSettings;

        public BarcodeReadRepository(IDbSettings dbSettings)
        {
            this.dbSettings = dbSettings;
        }

        public async Task<bool> ExistsAsync(string code)
        {
            var command = "PricingData.IsBarcodeExists";
            var param= new {code };
            var conn = dbSettings.CreateConnection();
            return await conn.QueryFirstAsync<bool>(
                command,
                param,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BarcodePriceDataReadingModel>> GetBarcodesDataAsync(
            Guid? productId = null,
            int? branchId = null,
            string? barcodeCode = null)
        {
            var command = "PricingData.GetBarcodesData";
            var param = new { ProductId = productId, BranchId = branchId, BarcodeCode = barcodeCode };

            using var conn = dbSettings.CreateConnection();

            return await conn.QueryAsync<BarcodePriceDataReadingModel>(
                command,
                param,
                commandType: CommandType.StoredProcedure);
        }

    }
}
