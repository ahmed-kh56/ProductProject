using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.Configurations.Suppliers
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers",
                tb => tb.UseSqlOutputClause(false));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedNever();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.ContactPhone)
                   .HasMaxLength(20);

            builder.Property(s => s.Scope)
                   .HasConversion<string>()
                   .IsRequired();
            builder.Property(p => p.Scope)
                    .HasMaxLength(30);

            builder.Property(s => s.CreatedAt)
                   .IsRequired();

            builder.Property(s => s.LastUpdate)
                   .IsRequired(false);

        }
    }
}
