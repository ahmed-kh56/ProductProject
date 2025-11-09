using MediatR;
using OutcomeOf;
using Product.Domain.Barcodes;


namespace Product.Application.Commands.Prices.CreateCustomBarcodePrice
{
    public record CreateCustomBarcodePriceCommand(
        string Code,
        decimal Price,
        decimal? LowistPrice,
        int BranchId):IRequest<OutcomeOf<PriceAccordingToBranch>>;
}
