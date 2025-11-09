using Product.Domain.Branchs;
using Product.Domain.Common;
using System.Text.Json.Serialization;

namespace Product.Domain.Barcodes
{
    public class PriceAccordingToBranch: IAuditable
    {
        public string BarcodeCode { get; private set; }
        public Barcode Barcode { get; private set; }
        public int BranchId { get; private set; } = 1;
        public Branch Branch { get; private set; }

        public decimal Price { get; private set; }
        public decimal? LowestPriceForSale { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        private PriceAccordingToBranch() { }


        public PriceAccordingToBranch(string barcode, decimal price, int branchId, decimal? lowestPrice = null)
        {

            BarcodeCode = barcode;
            BranchId = branchId;
            Price = price;
            LowestPriceForSale = lowestPrice ?? price;
        }
        [JsonConstructor]
        public PriceAccordingToBranch(
            string barcode,
            decimal price,
            int branchId,
            decimal lowestPrice,
            DateTime createdAt,
            DateTime lastUpdate)
        {

            BarcodeCode = barcode;
            BranchId = branchId;
            Price = price;
            LowestPriceForSale = lowestPrice;
            CreatedAt = createdAt;
            LastUpdate = lastUpdate;

        }


        public void Update(decimal? price,decimal? lowistPrice)
        {
            if(price is not null)
                Price = price.Value;

            if(lowistPrice is not null)
                LowestPriceForSale = lowistPrice.Value;



        }

    }
}
