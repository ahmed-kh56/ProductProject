using Product.Domain.Products;

namespace Product.Application.Common.DataReadingModels.ProductsData
{
    public class ProductHistoryDataNeeded
    {
        public ProductHistoryDataNeeded(ProductItem item)
        {
            Id = item.Id;
            Name = item.Name;
            EnglishName = item.EnglishName;
            SmallestUnitCost = item.SmallestUnitCost;
            IsAllowToSellOnline = item.IsAllowedOnline;
            IsActive = item.IsActive;
            transactionType = item.TransactionType;
            receiptType = item.ReceiptType;
            CatagoryId = item.CatagoryId;
            BrandId = item.BrandId;
            ProductGroupId = item.ProductGroupId;
            CountryOfOriginId = item.CountryOfOriginId;
            MainTaxId = item.MainTaxId;
            SubTaxId = item.SubTaxId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }

        public decimal SmallestUnitCost { get; set; }

        public bool IsAllowToSellOnline { get; set; }
        public bool IsActive { get; set; } 
        public ItemTransactionType transactionType { get; set; } = ItemTransactionType.Ordered;
        public ItemReceiptType receiptType { get; set; } = ItemReceiptType.Request;

        public int CatagoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductGroupId { get; set; }

        public int CountryOfOriginId { get; set; }


        public Guid? MainTaxId { get; set; }
        public Guid? SubTaxId { get; set; }





    }
}
