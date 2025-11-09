using Product.Application.Common.DataReadingModels.DropDown;
using Product.Domain.Branchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Interfaces
{
    public interface IBrancheReadRepository
    {
        Task<Branch?> GetBrancheByNameOrIdAsync(int? branchId =null,string? branchName =null);
        void Attach(Branch branch);
        Task<IEnumerable<BranchDropDownListForm>> GetBranchesAsync();
    }
}
