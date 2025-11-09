using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;
using Product.Domain.Products;

namespace Product.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler 
        (IProductWriteRepository _productRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateProductCommand, OutcomeOf<Guid>>
    {

        public async Task<OutcomeOf<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new ProductItem(
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

                await _productRepository.AddAsync(product);


                await _unitOfWork.SaveEntitiesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return product.Id;
            }
            catch (Exception ex)
            {
                return Error.Failure(description: $"Error creating product: {ex.Message}");
            }
        }

    }


}


