using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.ProductsData;
using Product.Application.Common.Interfaces;

namespace Product.Application.Queries.Products.GetProductData
{
    public class GetProductDataQueryHandler
        (IProductReadRepository _productReadRepository): IRequestHandler<GetProductDataQuery, OutcomeOf<ProductDetailsReadModel>>
    {
        public async Task<OutcomeOf<ProductDetailsReadModel>> Handle(GetProductDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productData = await _productReadRepository.GetDataModelAsync(request.ProductId);
                if (productData is null)
                {
                    return Error.NotFound(description: "Product May not be data added with this Id or data not enough");
                }
                return productData.ToOutcomeOf();

            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }




        }
    }
}
