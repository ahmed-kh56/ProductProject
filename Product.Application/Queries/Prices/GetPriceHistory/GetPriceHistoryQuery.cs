using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;
using Product.Application.Common.DataReadingModels.Prices;

namespace Product.Application.Queries.Prices.GetPriceHistory
{
    public record GetPriceHistoryQuery(
        string? Barcode,
        int? BranchId,
        int PageSize,
        int PageNum,
        bool IncludeUpdates,
        bool IncludeAdds,
        bool IncludeDeletes)
        : IRequest<OutcomeOf<IEnumerable<PriceHistryData>>>;
}
