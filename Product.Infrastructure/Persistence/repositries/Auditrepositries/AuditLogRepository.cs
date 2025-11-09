using Dapper;
using Product.Application.Common.DataReadingModels.Audits;
using Product.Application.Common.Interfaces;
using Product.Domain.Common;
using Product.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Product.Infrastructure.Persistence.repositries.Auditrepositries
{
    internal class AuditLogRepository : IAuditLogRepository
    {
        private readonly IDbSettings _dbSettings;

        public AuditLogRepository(IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }



        public async Task<IEnumerable<AuditLogEntry>> GetHistoryAsync(
            string entityName,
            string? entityId = null,
            int pageNumber = 0,
            int pageSize = 12,
            bool includeAdded = true,
            bool includeUpdated = true,
            bool includeDeleted = true)
        {
            var storedProcedure = HistoryProcedures.GetProcedureFor(entityName);

            var parameters = new
            {
                EntityId = entityId,
                PageNumber = pageNumber,
                PageSize = pageSize,
                IncludeAdded = includeAdded,
                IncludeUpdated = includeUpdated,
                IncludeDeleted = includeDeleted
            };

            using var connection = _dbSettings.CreateConnection();

            return await connection.QueryAsync<AuditLogEntry>(
                sql: storedProcedure,
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

    }
    public static class HistoryProcedures
    {
        private static readonly Dictionary<string, string> _procedureMap = new()
        {
            { DomainModelsNames.ProductItemName, "Auditing.sp_Get_ProductItem_ByActionAndEntity" },
            { DomainModelsNames.BarcodeName, "Auditing.sp_Get_Barcode_ByActionAndEntity" },
            { DomainModelsNames.PriceAccordingToBranchName, "Auditing.sp_Get_PriceAccordingToBranch_ByActionAndEntity" }
        };

        public static string GetProcedureFor(string entityName)
        {
            if (_procedureMap.TryGetValue(entityName, out var procedure))
                return procedure;

            throw new ArgumentException($"Unknown entity name: {entityName}");
        }
    }


}
