using Product.Domain.Common;
using Product.Domain.Products;
using System.Text.Json.Serialization;

namespace Product.Domain.Barcodes
{
    public class Barcode : IAuditable
    {
        public string Code { get; private set; }
        public string Notes { get; private set; }

        public BarcodeScope Scope { get; private set; }
        public BarcodeSize? Size { get; private set; }
        public byte UnitId { get; private set; }
        public UnitOfMeasurement Unit { get; private set; }
        public decimal UnitsCountPerPackage { get; private set; }

        public Guid ProductId { get; private set; }
        public ProductItem Product { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsAllowedOnline { get; private set; }

        public decimal ProfitMargin { get; private set; }
        public decimal WholesaleProfitMargin { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public ICollection<PriceAccordingToBranch> PriceByBranches { get; private set; } = new List<PriceAccordingToBranch>();



        public Barcode(
            string code,
            BarcodeScope scope,
            byte unitId,
            Guid productId,
            decimal unitsCountPerPackage,
            decimal profitMargin,
            decimal wholesaleProfitMargin,
            bool isActive,
            bool isAllowedOnline,
            string? notes = null)
        {
            Code = code;
            Scope = scope;
            UnitId = unitId;
            Notes = notes ?? "";
            ProductId = productId;
            UnitsCountPerPackage = unitsCountPerPackage;
            ProfitMargin = profitMargin;
            WholesaleProfitMargin = wholesaleProfitMargin;
            IsActive = isActive;
            IsAllowedOnline = isAllowedOnline;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(
            decimal? unitsCountPerPackage,
            decimal? profitMargin,
            decimal? wholesaleProfitMargin,
            bool? isActive,
            bool? isAllowedOnline,
            string? notes=null)
        {

            if (!string.IsNullOrWhiteSpace(notes))
                Notes = notes;

            if (unitsCountPerPackage.HasValue)
                UnitsCountPerPackage = unitsCountPerPackage.Value;

            if (profitMargin.HasValue)
                ProfitMargin = profitMargin.Value;

            if (wholesaleProfitMargin.HasValue)
                WholesaleProfitMargin = wholesaleProfitMargin.Value;

            if (isActive.HasValue)
                IsActive = isActive.Value;

            if (isAllowedOnline.HasValue)
                IsAllowedOnline = isAllowedOnline.Value;

            LastUpdate = DateTime.UtcNow;
        }

        private Barcode(string code)
        {
            Code = code;
        }

        public static Barcode CreateForDelete(string code)
            => new Barcode(code);
    }
}
