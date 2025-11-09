using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;

namespace Product.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler
        (IProductWriteRepository _productWriteRepository,
        IProductReadRepository _productReadRepository,
        IUnitOfWork _unitOfWork,
        IBarcodeWriteRepository _barcodeWriteRepository,
        IPriceWriteRepository _priceWriteRepository,
        IPriceReadRepository _priceReadRepository)
        : IRequestHandler<DeleteProductCommand, OutcomeOf<Done>>
    {

        public async Task<OutcomeOf<Done>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _productReadRepository.GetByIdAsync(request.Id);
                if (exists is null)
                {
                    return Error.Conflict("Product not found,Can't be Deleted");
                }


                var barcodes = await _barcodeWriteRepository.GetBarcodesByProductIdAsync(request.Id);

                var prices = await _priceReadRepository.GetAllPricesAsync(productId:request.Id);



                await _unitOfWork.StartTransactionAsync();


                if (prices.Any())
                {
                    _priceWriteRepository.AttachRangeAsUnChanged(prices);
                    _priceWriteRepository.DeleteBulk(prices);

                }
                if (barcodes.Any())
                {
                    _barcodeWriteRepository.AttachRangeAsUnChanged(barcodes);
                    _barcodeWriteRepository.DeleteBulk(barcodes);
                }

                _productWriteRepository.AttachAsUnChanged(exists);
                _productWriteRepository.Delete(exists);

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
