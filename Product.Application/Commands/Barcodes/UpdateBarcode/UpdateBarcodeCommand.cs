using MediatR;
using OutcomeOf;
using Product.Domain.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands.Barcodes.UpdateBarcode
{
    public record UpdateBarcodeCommand(
        string Code,
        decimal? UnitsCountPerPackage,
        decimal? ProfitMargin,
        decimal? WholesaleProfitMargin,
        bool? IsActive,
        bool? IsAllowedOnline,
        string? Notes
    ) : IRequest<OutcomeOf<Done>>;


}
