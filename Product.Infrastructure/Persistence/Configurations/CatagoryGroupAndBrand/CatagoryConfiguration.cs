using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.CatagoryGroupAndBrand;


namespace Product.Infrastructure.Persistence.Configurations.CatagoryGroupAndBrand
{
    public class CatagoryConfiguration : IEntityTypeConfiguration<Catagory>
    {
        public void Configure(EntityTypeBuilder<Catagory> builder)
        {
            builder.ToTable("Catagories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Catagory)
                   .HasForeignKey(p => p.CatagoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
