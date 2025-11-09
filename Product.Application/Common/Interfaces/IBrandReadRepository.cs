using Product.Application.Common.DataReadingModels.DropDown;
using Product.Domain.CatagoryGroupAndBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IBrandReadRepository
    {
        Task<IEnumerable<BrandDropDownListForm>> GetBrandsAsync();
    }
}
