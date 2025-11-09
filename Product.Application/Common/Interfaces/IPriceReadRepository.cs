using Product.Domain.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IPriceReadRepository
    {
        Task<PriceAccordingToBranch?> GetByBarcodeAndBranchAsync(string code, int branchId);
        Task<IEnumerable<PriceAccordingToBranch>> GetAllPricesAsync(string? code = null, Guid? productId = null);
    }
}
