using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries.Barcodes.GetProductBarcodes
{
    public record GetBarcodesByProductIdQuery(Guid ProductId,int BranchId=0):IRequest<OutcomeOf<IEnumerable<BarcodePriceDataReadingModel>>>;
}
