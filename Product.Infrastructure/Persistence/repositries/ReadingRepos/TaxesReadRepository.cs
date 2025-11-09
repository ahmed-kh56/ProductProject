using Dapper;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using Product.Domain.CatagoryGroupAndBrand;
using Product.Domain.Taxes;
using Product.Infrastructure.Persistence.DbSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class TaxesReadRepository : ITaxesReadRepository
    {
        private readonly IDbSettings _dbSettings;
        public TaxesReadRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }
        public async Task<IEnumerable<TaxDropDownForm>> GetTaxesDropDownForm(TaxType? type=null)
        {
            var paramslist = new { type= type.ToString()??null };
            var command = "[TaxesData].[GetTaxes]";

            using var conn = _dbSettings.CreateConnection();
            // not implemented
            //updated 
            return await conn.QueryAsync<TaxDropDownForm>(
                sql: command,
                param: paramslist,
                commandType:CommandType.StoredProcedure,
                commandTimeout: 30);
        }
    }
}
