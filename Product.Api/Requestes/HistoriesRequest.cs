using Azure.Core.GeoJson;
using Product.Application.Queries.Barcodes.GetBarcodeHistory;
using Product.Application.Queries.Prices.GetPriceHistory;
using Product.Application.Queries.Products.GetProductsHistory;

namespace Product.Api.Requestes
{
    public class HistoriesRequest
    {
        public int PageSize { get; set; } = 12;
        public int PageNumber { get; set; } = 0;
        public Including Including { get; set; }

        public GetProductHistoryQuery ToGetProductHistoryQuery(Guid? productId)
        {
            var (update, add,delete ) = GetIncludingFlags();

            return new GetProductHistoryQuery(
                productId,
                PageSize,
                PageNumber,
                update,
                add,
                delete);
        }
        public GetBarcodeHistoryQuery ToGetBarcodeHistoryQuery(string? code)
        {
            var (update, add, delete) = GetIncludingFlags();

            return new GetBarcodeHistoryQuery(
                code,
                PageSize,
                PageNumber,
                update,
                add,
                delete);
        }
        public GetPriceHistoryQuery ToGetPriceHistoryQuery(string? code,int? branchId)
        {
            var (update, add, delete) = GetIncludingFlags();

            return new GetPriceHistoryQuery(
                code,
                branchId,
                PageSize,
                PageNumber,
                update,
                add,
                delete);
        }

        private (bool includeUpdates, bool includeAdds, bool includeDeletes) GetIncludingFlags()
        {
            return (
                Including.HasFlag(Including.Updated),
                Including.HasFlag(Including.Added),
                Including.HasFlag(Including.Deleted)
            );
        }


    }

    [Flags]
    public enum Including
    {
        None = 0,
        Updated = 1,
        Added = 2,
        Deleted = 4,
        All = Updated | Added | Deleted
    }

}
