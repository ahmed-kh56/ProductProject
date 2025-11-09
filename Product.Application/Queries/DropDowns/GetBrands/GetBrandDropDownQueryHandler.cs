using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;

namespace Product.Application.Queries.DropDowns.GetBrands
{
    public class GetBrandDropDownQueryHandler 
        (IBrandReadRepository _brandRepository)
        : IRequestHandler<GetBrandDropDownQuery, OutcomeOf<IEnumerable<BrandDropDownListForm>>>
    {
        public async Task<OutcomeOf<IEnumerable<BrandDropDownListForm>>> Handle(GetBrandDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var brands = await _brandRepository.GetBrandsAsync();
                if (brands == null)
                {
                    return Error.NotFound(description: "No brands found.");
                }
                return brands.ToOutcomeOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }
    }
}
