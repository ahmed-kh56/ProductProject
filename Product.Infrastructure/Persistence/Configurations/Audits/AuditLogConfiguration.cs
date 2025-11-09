using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.Configurations.Audits
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(al => al.Id);

            builder.Property(al => al.EntityName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(al => al.EntityId)
                .IsRequired()
                .HasMaxLength(115);

            builder.Property(al => al.Action)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(al => al.OldValues)
                .IsRequired(false)
                .HasMaxLength(1500);

            builder.Property(al => al.Date)
                .IsRequired();

        }
    }
}
