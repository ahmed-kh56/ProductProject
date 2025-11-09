using MediatR;
using OutcomeOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands.Barcodes.DeleteBarcode
{
    public record DeleteBarcodeCommand(string Code):IRequest<OutcomeOf<Done>>;
}
