using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IProductWriteRepository
    {
        Task AddAsync(ProductItem product);
        void Delete(ProductItem product);
        void Update(ProductItem product);
        Task<ProductItem?> GetByIdAsync(Guid Id);
        void AttachAsUnChanged(ProductItem exists);
    }
}
