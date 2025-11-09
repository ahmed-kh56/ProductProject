using Microsoft.EntityFrameworkCore;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;

namespace Product.Infrastructure.Persistence.repositries.Barcderepositries
{
    internal class BarcodeWriteRepository : IBarcodeWriteRepository
    {
        private readonly ProductServiceDbContext dbContext;

        public BarcodeWriteRepository(ProductServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Barcode barcode)
        {
            await dbContext.AddAsync(barcode);
        }

        public void AttachRangeAsUnChanged(IEnumerable<Barcode> barcodes)
        {
            dbContext.Barcodes.AttachRange(barcodes);
        }

        public void Delete(Barcode barcode)
        {
            dbContext.Barcodes.Remove(barcode);
        }

        public void DeleteBulk(IEnumerable<Barcode> barcodes)
        {
            dbContext.Barcodes.RemoveRange(barcodes);
        }

        public async Task<IEnumerable<Barcode>> GetBarcodesByProductIdAsync(Guid productId)
        {
            return await dbContext.Barcodes.Where(b => b.ProductId == productId).ToListAsync();
        }

        public async Task<Barcode?> GetByCodeAsync(string code)
        {
            return await dbContext.Barcodes.FirstOrDefaultAsync(b => b.Code == code);
        }

        public void Update(Barcode barcode)
        {
            dbContext.Barcodes.Update(barcode);
        }
    }
}
