using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;

namespace Product.Application.Commands.Prices.UpdateBarcodePrice
{
    public class UpdateBarcodePriceCommandHandler(
        IPriceWriteRepository _priceRepository,
        IBarcodeReadRepository _barcodeRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<UpdateBarcodePriceCommand, OutcomeOf<Done>>
    {

        public async Task<OutcomeOf<Done>> Handle(UpdateBarcodePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _barcodeRepository.ExistsAsync(request.Code);
                if (!existing)
                {
                    return Error.NotFound(description:$"Barcode with code {request.Code} not found.");
                }

                var priceEntry = await _priceRepository.GetByBarcodeAndBranchAsync(request.Code, request.BranchId);

                if (priceEntry is null)
                {
                    return Error.NotFound(description:$"price wasnt found for barcode{request.Code} at branch {request.BranchId}");
                }

                await _unitOfWork.StartTransactionAsync();

                priceEntry.Update(request.Price, request.LowistPrice);
                await _unitOfWork.SaveEntitiesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return new Done();

            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }


        }
    }


}
