using MediatR;
using OutcomeOf;
using Product.Domain.CatagoryGroupAndBrand;

namespace Product.Application.Queries.DropDowns.GetCatagories;

public record GetCatagoriesDropDownQuery():IRequest<OutcomeOf<IEnumerable<Catagory>>>;


