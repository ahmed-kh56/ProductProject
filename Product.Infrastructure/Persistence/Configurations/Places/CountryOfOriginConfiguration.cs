using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.CatagoryGroupAndBrand;

namespace Product.Infrastructure.Persistence.Configurations.Places
{
    public class CountryOfOriginConfiguration : IEntityTypeConfiguration<CountryOfOrigin>
    {
        public void Configure(EntityTypeBuilder<CountryOfOrigin> builder)
        {
            builder.ToTable("CountriesOfOrigin",
                tb => tb.UseSqlOutputClause(false));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.ZCode)
                   .HasMaxLength(10);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.CountryOfOrigin)
                   .HasForeignKey(p => p.CountryOfOriginId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
