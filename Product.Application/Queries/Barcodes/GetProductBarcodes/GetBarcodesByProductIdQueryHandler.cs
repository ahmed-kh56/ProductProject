using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;
using Product.Application.Common.Interfaces;

namespace Product.Application.Queries.Barcodes.GetProductBarcodes
{
    public class GetBarcodesByProductIdQueryHandler
        (IBarcodeReadRepository _readRepository): IRequestHandler<GetBarcodesByProductIdQuery, OutcomeOf<IEnumerable<BarcodePriceDataReadingModel>>>
    {

        public async Task<OutcomeOf<IEnumerable<BarcodePriceDataReadingModel>>> Handle(GetBarcodesByProductIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var barcodes = await _readRepository.GetBarcodesDataAsync(request.ProductId, request.BranchId);


                if (barcodes is null || !barcodes.Any())
                {
                    return Error.NotFound(description: "no barcode prices found for that place");
                }

                var distinctBarcodes = barcodes
                    .GroupBy(b => b.BarcodeCode)
                    .Select(g => g
                        .OrderBy(b => b.BranchId == request.BranchId ? 0 : 1)
                        .First())
                    .ToList();



                return distinctBarcodes;

            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
