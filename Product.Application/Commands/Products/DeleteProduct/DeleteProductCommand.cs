using MediatR;
using OutcomeOf;

namespace Product.Application.Commands.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):IRequest<OutcomeOf<Done>>;
}
