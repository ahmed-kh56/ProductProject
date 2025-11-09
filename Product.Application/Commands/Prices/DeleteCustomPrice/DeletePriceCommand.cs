using MediatR;
using OutcomeOf;


namespace Product.Application.Commands.Prices.DeleteCustomPrice
{
    public record DeletePriceCommand(string Code, int BranchId):IRequest<OutcomeOf<Done>>;

}
