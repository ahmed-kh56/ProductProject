using Dapper;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;
using Product.Infrastructure.Persistence.DbSettings;

namespace Product.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class CatagoryReadRepository : ICatagoryReadRepository
    {
        private readonly IDbSettings _dbSettings;

        public CatagoryReadRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public async Task<IEnumerable<Catagory>> GetCatagoriesAsync()
        {
            using var conn = _dbSettings.CreateConnection();
            var command = "SELECT * FROM Catagories";
            return await conn.QueryAsync<Catagory>(command);

        }
    }
}
