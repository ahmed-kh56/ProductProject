using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;


namespace Product.Application.Commands.Prices.CreateCustomBarcodePrice
{
    public class CreateCustomBarcodePriceCommandHandler(
        IBarcodeReadRepository _barcodeRepository,
        IPriceWriteRepository _priceRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateCustomBarcodePriceCommand, OutcomeOf<PriceAccordingToBranch>>
    {
        public async Task<OutcomeOf<PriceAccordingToBranch>> Handle(CreateCustomBarcodePriceCommand request, CancellationToken cancellationToken)
        {


            try
            {
                var exists = await _barcodeRepository.ExistsAsync(request.Code);
                if (!exists)
                    return Error.Conflict(
                        code: "Conflict.AddCustomPriceToBarcode",
                        description: "Cant add a price to a not existing barcode");

                var priceToBeAdded = new PriceAccordingToBranch(
                    request.Code,
                    request.Price,
                    request.BranchId,
                    request.LowistPrice);



                await _unitOfWork.StartTransactionAsync();

                await _priceRepository.AddAsync(priceToBeAdded);

                await _unitOfWork.SaveEntitiesAsync();

                await _unitOfWork.CommitTransactionAsync();

                return priceToBeAdded;

            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
