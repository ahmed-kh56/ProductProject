using Product.Domain.Barcodes;

namespace Product.Application.Common.DataReadingModels.Barcodes
{
    public class BarcodeHistoryDataNeeded
    {
        public BarcodeHistoryDataNeeded(Barcode barcode)
        {
            Code = barcode.Code;
            Notes = barcode.Notes;
            Scope = barcode.Scope;
            Size = barcode.Size;
            UnitId = barcode.UnitId;
            UnitsCountPerPackage = barcode.UnitsCountPerPackage;
            IsActive = barcode.IsActive;
            IsAllowedOnline = barcode.IsAllowedOnline;
            ProfitMargin = barcode.ProfitMargin;
            WholesaleProfitMargin = barcode.WholesaleProfitMargin;


        }
        public string Code { get; set; }
        public string Notes { get; set; }
        public BarcodeScope Scope { get; set; }
        public BarcodeSize? Size { get; set; }
        public byte UnitId { get; set; }
        public decimal UnitsCountPerPackage { get; set; }
        public Guid ProductId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAllowedOnline { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal WholesaleProfitMargin { get; set; }


    }
}
