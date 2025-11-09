using Product.Domain.CatagoryGroupAndBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IProductGroupReadRepository
    {
        Task<IEnumerable<ProductGroup>> GetProductGroupsAsync();
    }
}
