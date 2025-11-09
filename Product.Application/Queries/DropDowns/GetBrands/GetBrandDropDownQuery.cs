using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.DropDown;


namespace Product.Application.Queries.DropDowns.GetBrands;

public record GetBrandDropDownQuery():IRequest<OutcomeOf<IEnumerable<BrandDropDownListForm>>>;
