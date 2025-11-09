using Product.Application.Commands.Barcodes.UpdateBarcode;
using Product.Domain.Barcodes;

namespace Product.Api.Requestes
{
    public class UpdateBarcodeRequest
    {
        public decimal? UnitsCountPerPackage { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? WholesaleProfitMargin { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAllowedOnline { get; set; }
        public string? Notes { get; set; }

        public UpdateBarcodeCommand ToUpdateCommand(string Barcode)
        => new UpdateBarcodeCommand(
            Barcode,
            UnitsCountPerPackage,
            ProfitMargin,
            WholesaleProfitMargin,
            IsActive,
            IsAllowedOnline,
            Notes
        );
    }



}
