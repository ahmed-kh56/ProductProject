using MediatR;
using OutcomeOf;

namespace Product.Application.Commands.Prices.UpdateBarcodePrice
{
    public record UpdateBarcodePriceCommand(
        string Code,
        decimal? Price,
        decimal? LowistPrice,
        int BranchId)
        : IRequest<OutcomeOf<Done>>;


}
