using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using Product.Domain.Barcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.Configurations.Pricing
{
    public class PriceAccordingToBranchConfiguration : IEntityTypeConfiguration<PriceAccordingToBranch>
    {
        public void Configure(EntityTypeBuilder<PriceAccordingToBranch> builder)
        {

            builder.ToTable("PricesAccordingToBranches",
                tb => tb.UseSqlOutputClause(false));
            builder.HasKey(pb => new {pb.BranchId,pb.BarcodeCode });

            builder.Property(pb => pb.BranchId)
                .IsRequired();
            builder.Property(pb => pb.BarcodeCode)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.LowestPriceForSale)
                .HasColumnType("decimal(18,2)");



            builder.HasOne(pb => pb.Barcode)
                .WithMany(p => p.PriceByBranches)
                .HasForeignKey(pb => pb.BarcodeCode)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pb => pb.Branch)
                .WithMany(b => b.PriceByBranches)
                .HasForeignKey(pb => pb.BranchId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
