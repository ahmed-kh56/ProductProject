using MediatR;
using OutcomeOf;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;

namespace Product.Application.Queries.DropDowns.GetGroup
{
    public class GetGroupDropDownQueryHandler
        (IProductGroupReadRepository _groupReadRepository) : IRequestHandler<GetGroupDropDownQuery, OutcomeOf<IEnumerable<ProductGroup>>>
    {

        public async Task<OutcomeOf<IEnumerable<ProductGroup>>> Handle(GetGroupDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var groups = await _groupReadRepository.GetProductGroupsAsync();
                if (groups == null)
                {
                    return Error.NotFound(description: "No groups found.");
                }
                return groups.ToOutcomeOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }


        }
    }
}
