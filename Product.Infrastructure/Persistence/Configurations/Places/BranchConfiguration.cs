using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Branchs;

namespace Product.Infrastructure.Persistence.Configurations.Places
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches", tb => tb.UseSqlOutputClause(false));

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .ValueGeneratedNever();

            builder.Property(b => b.BranchName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(b => b.BranchAddress)
                   .HasMaxLength(250);

            builder.Property(b => b.BranchPhone)
                   .HasMaxLength(20);
        }
    }

}
