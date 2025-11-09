using Product.Domain.Barcodes;

namespace Product.Application.Common.DataReadingModels.Barcodes
{
    public class BarcodeHistoryData
    {
        public BarcodeHistoryData(DateTime ChangedAt, string action,Barcode barcode)
        {
            if (barcode != null)
            {
                Price = new BarcodeHistoryDataNeeded(barcode);
                From = barcode.LastUpdate ?? barcode.CreatedAt;
                To = ChangedAt;
                Action = action;

            }
            else
            {
                From = ChangedAt;
                Action = action;
            }
        }
        public BarcodeHistoryDataNeeded Price { get; set; } = null;
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Action { get; set; }
    }
}
