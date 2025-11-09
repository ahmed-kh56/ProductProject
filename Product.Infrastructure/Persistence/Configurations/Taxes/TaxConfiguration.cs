using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Taxes;


namespace Product.Infrastructure.Persistence.Configurations.Taxes
{
    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.ToTable("Taxes",
                tb => tb.UseSqlOutputClause(false));

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Description)
                   .HasMaxLength(300);

            builder.Property(t => t.Rate)
                   .HasColumnType("decimal(5,2)")
                   .IsRequired();

            builder.Property(t => t.TaxType)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(t => t.TaxType)
                    .HasMaxLength(10);

            builder.Property(t => t.CreatedAt)
                    .IsRequired();

            builder.Property(t => t.LastUpdate)
                    .IsRequired(false);


            builder.HasMany(t => t.MainTaxedproducts)
                   .WithOne(pt => pt.MainTax)
                   .HasForeignKey(pt => pt.MainTaxId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.SubTaxedProduct)
                   .WithOne(pt => pt.SubTax)
                   .HasForeignKey(pt => pt.SubTaxId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }

}
