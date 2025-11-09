using MediatR;
using OutcomeOf;
using Product.Domain.CatagoryGroupAndBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries.DropDowns.GetGroup
{
    public record GetGroupDropDownQuery()
        :IRequest<OutcomeOf<IEnumerable<ProductGroup>>>;
}
