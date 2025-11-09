using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;

namespace Product.Application.Queries.Barcodes.GetBarcodeHistory
{
    public record GetBarcodeHistoryQuery(
        string? Barcode,
        int PageSize,
        int PageNum,
        bool IncludeUpdates,
        bool IncludeAdds,
        bool IncludeDeletes)
        :IRequest<OutcomeOf<IEnumerable<BarcodeHistoryData>>>;


}
