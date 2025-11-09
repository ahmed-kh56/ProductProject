using MediatR;
using OutcomeOf;
using Product.Domain.Barcodes;

namespace Product.Application.Commands.Barcodes.CreateBarcode
{
    public record CreateBarcodeCommand(
        Guid ProductId,
        string Code,
        BarcodeScope Scope,
        byte UnitId,
        decimal UnitsCountPerPackage,
        decimal ProfitMargin,
        decimal WholesaleProfitMargin,
        decimal SmallestUnitPrice,
        decimal LowestPriceForSalePerSmallestUnit,
        bool IsActive,
        bool IsAllowedOnline,
        string? Notes = null
    ) : IRequest<OutcomeOf<Done>>;




}
