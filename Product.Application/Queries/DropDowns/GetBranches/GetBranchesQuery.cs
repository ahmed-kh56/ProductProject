using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries.DropDowns.GetBranches
{
    public record GetBranchesQuery():IRequest<OutcomeOf<IEnumerable<BranchDropDownListForm>>>;
    public class GetBranchesQueryHandler
        (IBrancheReadRepository _brancheReadRepository) : IRequestHandler<GetBranchesQuery, OutcomeOf<IEnumerable<BranchDropDownListForm>>>
    {
        public async Task<OutcomeOf<IEnumerable<BranchDropDownListForm>>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var branchs = await _brancheReadRepository.GetBranchesAsync();
                if (!branchs.Any())
                    return Error.NotFound();
                return branchs.ToList();

            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }




        }
    }
}
