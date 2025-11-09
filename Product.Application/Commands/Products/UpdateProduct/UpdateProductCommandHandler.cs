using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;

namespace Product.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler
        (IProductWriteRepository _productRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateProductCommand, OutcomeOf<Done>>
    {

        public async Task<OutcomeOf<Done>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id);

                if (product == null)
                {
                    return Error.NotFound(description: $"Product with Id {request.Id} was not found.");
                }


                product.Update(
                    request.Name,
                    request.EnglishName,
                    request.IsActive,
                    request.IsAllowedOnline,
                    request.TransactionType,
                    request.ReceiptType,
                    request.SmallestUnitCost,
                    request.CatagoryId,
                    request.BrandId,
                    request.ProductGroupId,
                    request.CountryOfOriginId,
                    request.MainTaxId,
                    request.SubTaxId
                );


                await _unitOfWork.StartTransactionAsync();

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
