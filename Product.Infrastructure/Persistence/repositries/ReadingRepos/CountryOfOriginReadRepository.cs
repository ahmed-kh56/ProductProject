using Dapper;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence.DbSettings;


namespace Product.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class CountryOfOriginReadRepository: ICountryOfOriginReadRepository
    {
        private readonly IDbSettings _dbSettings;

        public CountryOfOriginReadRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public Task<IEnumerable<CountryOfOriginDropDownListForm>> GetCountryOfOriginAsDropDownFormAsync()
        {
            var conn = _dbSettings.CreateConnection();
            var command = "SELECT Id,Name FROM CountriesOfOrigin";
            return conn.QueryAsync<CountryOfOriginDropDownListForm>(command);

        }
    }
}
