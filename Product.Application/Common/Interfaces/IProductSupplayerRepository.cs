using Product.Application.Common.DataReadingModels.Supplayeres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IProductSupplayerRepository
    {
        Task<IEnumerable<ProductSupplayerReadForm>> GetByPhoneAsync(Guid? productId, string phone);

    }
}
