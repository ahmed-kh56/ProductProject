using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries.Barcodes.GetDeletedBarcodes
{
    // no pagenation, as the deleted barcodes are expected to be few
    public record GetDeletedBarcodesQuery():IRequest<OutcomeOf<IEnumerable<BarcodeHistoryData>>>;


}
