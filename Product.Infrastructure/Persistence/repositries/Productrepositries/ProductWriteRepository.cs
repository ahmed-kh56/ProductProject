using Microsoft.EntityFrameworkCore;
using Product.Application.Common.Interfaces;
using Product.Domain.Products;

namespace Product.Infrastructure.Persistence.repositries.Productrepositries
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        private readonly ProductServiceDbContext _context;

        public ProductWriteRepository(ProductServiceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductItem product)
        {
            await _context.Products.AddAsync(product);
        }

        public void AttachAsUnChanged(ProductItem exists)
        {
            _context.Attach(exists);
        }

        public void Delete(ProductItem product)
        {
            _context.Products.Remove(product);
        }
        public async Task<ProductItem?> GetByIdAsync(Guid Id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
        }
        public void Update(ProductItem product)
        {
            _context.Products.Update(product);
        }
    }
}
