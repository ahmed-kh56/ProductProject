using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;

namespace Product.Application.Commands.Barcodes.UpdateBarcode
{
    public class UpdateBarcodeCommandHandler
        (IBarcodeWriteRepository _barcodeWriteRepository,
        IUnitOfWork _unitOfWork): IRequestHandler<UpdateBarcodeCommand, OutcomeOf<Done>>
    {

        public async Task<OutcomeOf<Done>> Handle(UpdateBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var barcode = await _barcodeWriteRepository.GetByCodeAsync(request.Code);
                if (barcode == null)
                {
                    return Error.NotFound("Barcode not found");
                }
                barcode.Update(
                    request.UnitsCountPerPackage,
                    request.ProfitMargin,
                    request.WholesaleProfitMargin,
                    request.IsActive,
                    request.IsAllowedOnline,
                    request.Notes
                    );




                await _unitOfWork.StartTransactionAsync();

                await _unitOfWork.SaveEntitiesAsync();

                await _unitOfWork.CommitTransactionAsync();
                return new Done();
            }
            catch (Exception ex)
            {
                return Error.Failure($"An error occurred while updating the barcode: {ex.Message}");
            }


        }
    }


}
