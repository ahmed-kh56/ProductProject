using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;
using Product.Domain.Products;


namespace Product.Application.Queries.Products.GetAllProducts
{
    public class GetProductsQueryHandler
        (IProductReadRepository _productRepository)
        : IRequestHandler<GetProductsQuery, OutcomeOf<IEnumerable<ProductItem>>>
    {

        public async Task<OutcomeOf<IEnumerable<ProductItem>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                if (products == null || !products.Any())
                {
                    return Error.NotFound(description: "No products found.");
                }
                return products.ToOutcomeOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }
        }
    }



}
