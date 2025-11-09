using Dapper;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;
using Product.Infrastructure.Persistence.DbSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class ProductGroupReadRepository : IProductGroupReadRepository
    {
        private readonly IDbSettings _dbSettings;
        public ProductGroupReadRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }
        public Task<IEnumerable<ProductGroup>> GetProductGroupsAsync()
        {
            var conn = _dbSettings.CreateConnection();
            var command = "SELECT Id,Name FROM ProductGroups";
            return conn.QueryAsync<ProductGroup>(command);
        }
    }
}
