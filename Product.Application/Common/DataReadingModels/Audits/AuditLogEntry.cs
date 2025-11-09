using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.DataReadingModels.Audits
{
    public class AuditLogEntry
    {
        public Guid Id { get; set; }

        public string EntityId { get; set; } = string.Empty;
        public string Action { get; set; } = default!;

        public string? OldValues { get; set; }
        public DateTime Date { get; set; }

    }

}
