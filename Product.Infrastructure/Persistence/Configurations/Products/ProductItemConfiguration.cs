using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.Configurations.Products
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable(
                "Products",
                tb => tb.UseSqlOutputClause(false));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.EnglishName)
                   .HasMaxLength(200);






            builder.Property(p => p.TransactionType)
                   .HasConversion<string>()
                   .IsRequired();
            builder.Property(p=>p.TransactionType)
                    .HasMaxLength(30);
            builder.Property(p => p.ReceiptType)
                   .HasConversion<string>()
                   .IsRequired();
            builder.Property(p => p.ReceiptType)
                    .HasMaxLength(30);
            builder.Property(p => p.IsActive)
                     .IsRequired();




            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.LastUpdate)
                   .IsRequired(false);




            builder.HasOne(p=>p.MainTax)
                .WithMany(t=>t.MainTaxedproducts)
                .HasForeignKey(p=>p.MainTaxId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.SubTax)
                .WithMany(t => t.SubTaxedProduct)
                .HasForeignKey(p => p.SubTaxId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p=>p.Barcodes)
                .WithOne(Se=>Se.Product)
                .HasForeignKey(se=>se.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
