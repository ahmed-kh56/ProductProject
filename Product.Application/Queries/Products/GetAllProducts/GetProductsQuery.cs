using MediatR;
using OutcomeOf;
using Product.Domain.Products;


namespace Product.Application.Queries.Products.GetAllProducts
{
    public record GetProductsQuery():IRequest<OutcomeOf<IEnumerable<ProductItem>>>;



}
