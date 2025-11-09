using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.CatagoryGroupAndBrand;

namespace Product.Infrastructure.Persistence.Configurations.CatagoryGroupAndBrand
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.ToTable("ProductGroups");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(g => g.Products)
                   .WithOne(p => p.ProductGroup)
                   .HasForeignKey(p => p.ProductGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
