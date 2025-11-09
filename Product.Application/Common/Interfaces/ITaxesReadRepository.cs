using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Queries.DropDowns.GetBrands;
using Product.Domain.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface ITaxesReadRepository
    {
        Task<IEnumerable<TaxDropDownForm>> GetTaxesDropDownForm(TaxType? type = null);
    }
}
