using Product.Application.Common.DataReadingModels.Barcodes;
using Product.Domain.Barcodes;
using Product.Domain.Branchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.DataReadingModels.Prices
{
    public class PriceHistryData
    {

        public PriceHistryData(DateTime ChangedAt, string action, PriceAccordingToBranch price)
        {
            if (price != null)
            {
                Price = new PriceHistoryDataNeeded(price);
                From = price.LastUpdate ?? price.CreatedAt;
                To = ChangedAt;
                Action = action;

            }
            else
            {
                From = ChangedAt;
                Action = action;
            }
        }

        public PriceHistoryDataNeeded Price { get; set; } = null;
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Action { get; set; }
    }

    public class PriceHistoryDataNeeded
    {
        public string BarcodeCode { get; private set; }
        public int BranchId { get; private set; } = 1;

        public decimal Price { get; private set; }
        public decimal? LowestPriceForSale { get; private set; }


        public PriceHistoryDataNeeded(PriceAccordingToBranch price)
        {
            BarcodeCode = price.BarcodeCode;
            BranchId = price.BranchId;
            Price = price.Price;
            LowestPriceForSale = price.LowestPriceForSale;
        }
    }
}
