using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;
using Product.Domain.Branchs;


namespace Product.Application.Commands.Barcodes.CreateBarcode
{
    public class CreateBarcodeCommandHandler
        (IBarcodeWriteRepository _barcodeRepository,
        IBarcodeReadRepository _readRepository,
        IPriceWriteRepository _priceRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateBarcodeCommand, OutcomeOf<Done>>
    {
        public async Task<OutcomeOf<Done>> Handle(CreateBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _readRepository.ExistsAsync(request.Code);
                if (exists)
                    return Error.Forbidden(description: "There is already a barcode with the same code");

                


                var barcode = new Barcode(
                    request.Code,
                    request.Scope,
                    request.UnitId,
                    request.ProductId,
                    request.UnitsCountPerPackage,
                    request.ProfitMargin,
                    request.WholesaleProfitMargin,
                    request.IsActive,
                    request.IsAllowedOnline,
                    request.Notes
                );


                var defaultPrice = new PriceAccordingToBranch
                    (request.Code,
                    request.SmallestUnitPrice,
                    1, //default branch id
                    request.LowestPriceForSalePerSmallestUnit
                    );



                await _unitOfWork.StartTransactionAsync();


                await _priceRepository.AddAsync(defaultPrice);
                await _barcodeRepository.AddAsync(barcode);
                await _unitOfWork.SaveEntitiesAsync();


                await _unitOfWork.CommitTransactionAsync();


                return new Done();

            }
            catch(Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
