using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Barcodes;

namespace Product.Infrastructure.Persistence.Configurations.Pricing
{
    public class UnitOfMeasurementConfiguration : IEntityTypeConfiguration<UnitOfMeasurement>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasurement> builder)
        {
            builder.ToTable("UnitOfMeasurement",
                tb => tb.UseSqlOutputClause(false));

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .ValueGeneratedNever();

            builder.Property(u => u.UnitName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(u => u.Barcodes)
                   .WithOne(su => su.Unit)
                   .HasForeignKey(su => su.UnitId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
