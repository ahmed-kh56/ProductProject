using Microsoft.EntityFrameworkCore;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;

namespace Product.Infrastructure.Persistence.repositries.Barcderepositries
{
    internal class PriceWriteRepository : IPriceWriteRepository
    {
        private readonly ProductServiceDbContext dbContext;

        public PriceWriteRepository(ProductServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(PriceAccordingToBranch price)
        {
            await dbContext.AddAsync(price);
        }

        public void AttachAsUnChanged(PriceAccordingToBranch price)
        {
            dbContext.PricesByBranches.Attach(price);
        }

        public void Delete(PriceAccordingToBranch price)
        {
            dbContext.PricesByBranches.Remove(price);
        }
        public void AttachRangeAsUnChanged(IEnumerable<PriceAccordingToBranch> prices)
        {
            dbContext.PricesByBranches.AttachRange(prices);
        }


        public void DeleteBulk(IEnumerable<PriceAccordingToBranch> prices)
        {
            dbContext.PricesByBranches.RemoveRange(prices);
        }

        public async Task<IEnumerable<PriceAccordingToBranch>> GetAllPricesForCode(string code)
        {
            return await dbContext.PricesByBranches.Where(p => p.BarcodeCode == code).ToListAsync();
        }

        public async Task<IEnumerable<PriceAccordingToBranch>> GetAllPricesForProduct(Guid productId)
        {
            return await dbContext.PricesByBranches.Where(p=>p.Barcode.ProductId ==productId).ToListAsync();
        }

        public async Task<PriceAccordingToBranch?> GetByBarcodeAndBranchAsync(string code, int branchId)
        {
            return await dbContext.PricesByBranches.FirstOrDefaultAsync(p => p.BarcodeCode == code && p.BranchId == branchId);
        }


    }
}
