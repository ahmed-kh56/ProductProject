using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;

namespace Product.Application.Commands.Prices.DeleteCustomPrice
{
    public class DeletePriceCommandHandler
        (IBarcodeReadRepository _barcodeRepository,
        IPriceWriteRepository _priceRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<DeletePriceCommand, OutcomeOf<Done>>
    {
        public async Task<OutcomeOf<Done>> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _barcodeRepository.ExistsAsync(request.Code);
                if (!exists)
                    return Error.Conflict(
                        description: "Cant delete price no barcode found with the same code");
                var priceToBeDeleted = await _priceRepository.GetByBarcodeAndBranchAsync(request.Code,request.BranchId);
                if (priceToBeDeleted is null)
                    return Error.NotFound(
                        description: "no prices allocated for that branch with this barcode");

                await _unitOfWork.StartTransactionAsync();
                _priceRepository.Delete(priceToBeDeleted);
                await _unitOfWork.StartTransactionAsync();
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
