using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;

namespace Product.Application.Queries.DropDowns.GetCatagories
{
    public class GetCatagoriesDropDownQueryHandler
        (ICatagoryReadRepository _catagoryRepository)
        : IRequestHandler<GetCatagoriesDropDownQuery, OutcomeOf<IEnumerable<Catagory>>>
    {
        public async Task<OutcomeOf<IEnumerable<Catagory>>> Handle(GetCatagoriesDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var catagories = await _catagoryRepository.GetCatagoriesAsync();
                if (catagories == null)
                {
                    return Error.NotFound(description: "No catagories found.");
                }
                return catagories.ToOutcomeOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }
    }
}


