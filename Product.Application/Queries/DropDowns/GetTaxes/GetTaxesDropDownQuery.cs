using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.DropDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries.DropDowns.GetTaxes
{
    public record GetTaxesDropDownQuery(string TaxType):IRequest<OutcomeOf<IEnumerable<TaxDropDownForm>>>;
}
