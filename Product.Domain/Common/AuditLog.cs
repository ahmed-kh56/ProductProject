
namespace Product.Domain.Common
{
    public class AuditLog
    {
        public Guid Id { get; private set; }

        public string EntityName { get; private set; } = default!;
        public string EntityId { get; private set; } = default!;
        public string Action { get; private set; } = default!;
        public string? OldValues { get; private set; }
        public DateTime Date { get; private set; }

        private AuditLog() { }

        public AuditLog(string entityName, string entityId, string action, string? oldValues)
        {
            Id = Guid.NewGuid();
            EntityName = entityName;
            EntityId = entityId;
            Action = action;
            OldValues = oldValues;
            Date = DateTime.UtcNow;
        }
    }

}
