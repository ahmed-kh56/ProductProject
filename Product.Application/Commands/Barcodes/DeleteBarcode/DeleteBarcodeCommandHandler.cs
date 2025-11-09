using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;

namespace Product.Application.Commands.Barcodes.DeleteBarcode
{
    public class DeleteBarcodeCommandHandler
        (IBarcodeWriteRepository _barcodeRepository,
        IUnitOfWork _unitOfWork,
        IPriceWriteRepository _priceRepository) : IRequestHandler<DeleteBarcodeCommand, OutcomeOf<Done>>
    {

        public async Task<OutcomeOf<Done>> Handle(DeleteBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var barcode = await _barcodeRepository.GetByCodeAsync(request.Code);
                if (barcode == null)
                {
                    return Error.NotFound(
                        code: "BarcodeNotFound",
                        description: "no barcode found with the sended code");
                }
                var prices = await _priceRepository.GetAllPricesForCode(request.Code);

                await _unitOfWork.StartTransactionAsync();

                _barcodeRepository.Delete(barcode);
                _priceRepository.DeleteBulk(prices);
                await _unitOfWork.SaveEntitiesAsync();

                await _unitOfWork.CommitTransactionAsync();

                return new Done();
            }
            catch (Exception ex)
            {
                return Error.Failure(
                    code: "DeleteBarcodeFailure",
                    description: $"An error occurred while deleting the barcode: {ex.Message}");
            }
        }
    }
}
