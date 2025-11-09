using Product.Application.Commands.Prices.CreateCustomBarcodePrice;
using Product.Application.Commands.Prices.UpdateBarcodePrice;

namespace Product.Api.Requestes
{
    public class CustomPriceRequest
    {
        public string Barcode { get; set; }
        public decimal? Price { get; set; }
        public decimal? LowistPrice { get; set; }
        public int BranchId { get; set; }
        public CreateCustomBarcodePriceCommand ToCreateCommand()
        {
            return new CreateCustomBarcodePriceCommand(Barcode, Price!.Value, LowistPrice, BranchId);
        }
        // not used currntly
        public UpdateBarcodePriceCommand ToUpdateCommand()
        {
            return new UpdateBarcodePriceCommand(Barcode, Price, LowistPrice, BranchId);
        }

    }
    public class UpdateCustomPriceRequest
    {
        public decimal? Price { get; set; }
        public decimal? LowistPrice { get; set; }

        public UpdateBarcodePriceCommand ToUpdateCommand(string Barcode, int BranchId)
        {
            return new UpdateBarcodePriceCommand(Barcode, Price, LowistPrice, BranchId);
        }

    }



}
