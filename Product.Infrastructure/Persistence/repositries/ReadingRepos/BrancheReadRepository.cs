using Dapper;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using Product.Domain.Branchs;
using Product.Infrastructure.Persistence.DbSettings;
using System.Data;
namespace Product.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class BrancheReadRepository : IBrancheReadRepository
    {
        private readonly IDbSettings _dbSettings;
        private readonly ProductServiceDbContext _context;

        public BrancheReadRepository(IDbSettings dbSettings, ProductServiceDbContext context)
        {
            _dbSettings = dbSettings;
            _context = context;
        }

        public void Attach(Branch branch)
        {
            _context.Branches.Attach(branch);
        }

        public async Task<Branch?> GetBrancheByNameOrIdAsync(int? branchId = null, string? branchName = null)
        {
            const string sql = "[PricingData].[GetBranchByNameOrId]";

            var parameters = new
            {
                BranchId = branchId,
                BranchName = branchName
            };

            using var connection = _dbSettings.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Branch>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


        public Task<IEnumerable<BranchDropDownListForm>> GetBranchesAsync()
        {
            var conn = _dbSettings.CreateConnection();
            var command = "SELECT Id,BranchName FROM Branches";
            return conn.QueryAsync<BranchDropDownListForm> (command);

        }
    }
}
