using Product.Domain.Barcodes;
using Product.Domain.Branchs;


namespace Product.Application.Common.DataReadingModels.Barcodes
{
    public class BarcodePriceDataReadingModel
    {

        public string BarcodeCode { get; set; } = string.Empty;
        public BarcodeScope BarcodeScope { get; set; }

        public byte UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public decimal UnitsCountPerPackage { get; set; }

        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LowestPriceForSale { get; set; }

        public decimal ProfitMargin { get; set; }
        public decimal WholesaleProfitMargin { get; set; }

        public bool IsAllowedOnline { get; set; }
        public string? Notes { get; set; }

        public bool IsActive { get; set; }

        public Guid ProductId { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;



        public override bool Equals(object obj)
        {
            if (obj is not BarcodePriceDataReadingModel other) return false;
            return BarcodeCode == other.BarcodeCode && BranchId==other.BranchId;
        }

        public override int GetHashCode()
        {
            return 11* BarcodeCode.GetHashCode()*BranchId.GetHashCode();
        }
    }

}
