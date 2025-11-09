using Product.Domain.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IPriceWriteRepository
    {
        Task AddAsync(PriceAccordingToBranch price);
        Task<IEnumerable<PriceAccordingToBranch>> GetAllPricesForCode(string code);
        Task<IEnumerable<PriceAccordingToBranch>> GetAllPricesForProduct(Guid productId);
        void DeleteBulk(IEnumerable<PriceAccordingToBranch> prices);
        Task<PriceAccordingToBranch?> GetByBarcodeAndBranchAsync(string code, int branchId);
        void Delete(PriceAccordingToBranch price);
        void AttachAsUnChanged(PriceAccordingToBranch price);
        void AttachRangeAsUnChanged(IEnumerable<PriceAccordingToBranch> prices);

    }
}
