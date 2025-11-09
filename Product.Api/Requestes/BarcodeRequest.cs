using Product.Application.Commands.Barcodes.CreateBarcode;
using Product.Application.Commands.Barcodes.UpdateBarcode;
using Product.Domain.Barcodes;

namespace Product.Api.Requestes
{
    public class BarcodeRequest
    {
        public string? Code { get; set; }
        public BarcodeScope? Scope { get; set; }
        public byte? UnitId { get; set; }
        public decimal? UnitsCountPerPackage { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? WholesaleProfitMargin { get; set; }
        public decimal? Price { get; set; }
        public decimal? LowestPriceForSale { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAllowedOnline { get; set; }
        public string? Notes { get; set; }

        public CreateBarcodeCommand ToCreateCommand(Guid productId)
            => new CreateBarcodeCommand(
                productId,
                Code!,
                Scope ?? BarcodeScope.Internal,
                UnitId ?? 1,
                UnitsCountPerPackage ?? 1,
                ProfitMargin ?? 10,
                WholesaleProfitMargin ?? 10,
                Price ?? 0,
                LowestPriceForSale ?? Price ?? 0,
                IsActive ?? true,
                IsAllowedOnline ?? false,
                Notes
            );


        //not used currently
        public UpdateBarcodeCommand ToUpdateCommand()
            => new UpdateBarcodeCommand(
                Code,
                UnitsCountPerPackage,
                ProfitMargin,
                WholesaleProfitMargin,
                IsActive,
                IsAllowedOnline,
                Notes
            );
    }



}
