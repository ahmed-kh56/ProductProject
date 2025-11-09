using Product.Application.Common.DataReadingModels.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IBarcodeReadRepository
    {
        Task<bool> ExistsAsync(string code);
        Task<IEnumerable<BarcodePriceDataReadingModel>> GetBarcodesDataAsync(
            Guid? productId = null,
            int? branchId = null,
            string? barcodeCode = null);
        }
}
