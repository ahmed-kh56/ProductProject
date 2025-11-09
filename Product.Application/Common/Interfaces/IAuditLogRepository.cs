using Product.Application.Common.DataReadingModels.Audits;

namespace Product.Application.Common.Interfaces
{
    public interface IAuditLogRepository
    {
        Task<IEnumerable<AuditLogEntry>> GetHistoryAsync(
            string entityName,
            string? entityId = null,
            int pageNumber = 0,
            int pageSize = 12,
            bool includeAdded = true,
            bool includeUpdated = true,
            bool includeDeleted = true);


    }
}
