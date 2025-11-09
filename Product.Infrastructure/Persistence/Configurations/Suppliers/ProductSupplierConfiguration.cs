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
    public class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.ToTable("ProductSuppliers",
                tb => tb.UseSqlOutputClause(false));
            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.Id)
                   .ValueGeneratedNever();

            builder.Property(ps => ps.CreatedAt)
                   .IsRequired();

            builder.Property(ps => ps.LastUpdate)
                   .IsRequired(false);

            // العلاقة مع ProductItem
            builder.HasOne(ps => ps.Product)
                   .WithMany(p => p.ProductSuppliers)
                   .HasForeignKey(ps => ps.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // العلاقة مع Supplier
            builder.HasOne(ps => ps.Supplier)
                   .WithMany(s => s.ProductSuppliers)
                   .HasForeignKey(ps => ps.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
