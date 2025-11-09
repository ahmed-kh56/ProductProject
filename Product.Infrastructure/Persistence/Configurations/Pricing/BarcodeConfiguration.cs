using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Barcodes;

namespace Product.Infrastructure.Persistence.Configurations.Pricing
{

    public class BarcodeConfiguration : IEntityTypeConfiguration<Barcode>
    {
        public void Configure(EntityTypeBuilder<Barcode> builder)
        {
            builder.ToTable("Barcodes",
                tb => tb.UseSqlOutputClause(false));

            builder.HasKey(b => b.Code);



            builder.Property(b => b.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Scope)
                   .HasConversion<string>()
                   .IsRequired();
            builder.Property(b => b.Scope)
                    .HasMaxLength(30);
            builder.Property(b=>b.Size)
                   .HasConversion<string?>()
                   .IsRequired(false)
                   .HasMaxLength(12);


            builder.Property(p => p.Notes)
                    .HasMaxLength(800);

            builder.Property(b => b.CreatedAt)
                   .IsRequired();

            builder.Property(b => b.LastUpdate)
                   .IsRequired(false);


        }
    }

}
