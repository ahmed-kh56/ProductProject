using Dapper;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence.DbSettings;

namespace Product.Infrastructure.Persistence.repositries.ReadingRepos
{
    public class BrandReadRepository : IBrandReadRepository
    {

        private readonly IDbSettings _dbSettings;
        public BrandReadRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }
        public Task<IEnumerable<BrandDropDownListForm>> GetBrandsAsync()
        {
            var conn = _dbSettings.CreateConnection();
            var command = "SELECT Id,Name FROM Brands";
            return conn.QueryAsync<BrandDropDownListForm>(command);

        }

    }
}
