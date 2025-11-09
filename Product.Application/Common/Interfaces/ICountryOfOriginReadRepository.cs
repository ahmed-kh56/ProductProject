using Product.Application.Common.DataReadingModels.DropDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface ICountryOfOriginReadRepository
    {
        Task<IEnumerable<CountryOfOriginDropDownListForm>> GetCountryOfOriginAsDropDownFormAsync();
    }
}
