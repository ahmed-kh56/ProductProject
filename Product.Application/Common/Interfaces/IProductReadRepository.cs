using OutcomeOf;
using Product.Application.Common.DataReadingModels.ProductsData;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IProductReadRepository
    {
        Task<bool> ExistsAsync(Guid id);
        Task<IEnumerable<ProductItem>> GetAllAsync();
        Task<ProductItem?> GetByIdAsync(Guid ProductId);
        Task<ProductDetailsReadModel?> GetDataModelAsync(Guid ProductId);
    }
}
