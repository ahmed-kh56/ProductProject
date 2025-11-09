using Newtonsoft.Json;
using Product.Domain.Barcodes;
using Product.Domain.CatagoryGroupAndBrand;
using Product.Domain.Common;
using Product.Domain.Suppliers;
using Product.Domain.Taxes;


namespace Product.Domain.Products
{
    public class ProductItem : IAuditable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string EnglishName { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsAllowedOnline { get; private set; }

        public ItemTransactionType TransactionType { get; private set; } = ItemTransactionType.Ordered;
        public ItemReceiptType ReceiptType { get; private set; } = ItemReceiptType.Request;

        public decimal SmallestUnitCost { get; private set; }

        public int CatagoryId { get; private set; }
        public Catagory Catagory { get; private set; }

        public int BrandId { get; private set; }
        public Brand Brand { get; private set; }

        public int ProductGroupId { get; private set; }
        public ProductGroup ProductGroup { get; private set; }

        public int CountryOfOriginId { get; private set; }
        public CountryOfOrigin CountryOfOrigin { get; private set; }

        public Guid? MainTaxId { get; private set; }
        public Tax? MainTax { get; private set; }

        public Guid? SubTaxId { get; private set; }
        public Tax? SubTax { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; private set; } = new List<ProductSupplier>();
        public ICollection<Barcode> Barcodes { get; private set; } = new List<Barcode>();


        private ProductItem() { }

        public ProductItem(
            string name,
            string englishName,
            bool isActive,
            bool isAllowedOnline,
            ItemTransactionType transactionType,
            ItemReceiptType receiptType,
            decimal smallestUnitCost,
            int catagoryId,
            int brandId,
            int productGroupId,
            int countryOfOriginId,
            Guid? mainTaxId = null,
            Guid? subTaxId = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            EnglishName = englishName;
            IsActive = isActive;
            IsAllowedOnline = isAllowedOnline;
            TransactionType = transactionType;
            ReceiptType = receiptType;
            SmallestUnitCost = smallestUnitCost;
            CatagoryId = catagoryId;
            BrandId = brandId;
            ProductGroupId = productGroupId;
            CountryOfOriginId = countryOfOriginId;
            MainTaxId = mainTaxId;
            SubTaxId = subTaxId;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(
            string? name,
            string? englishName,
            bool? isActive,
            bool? isAllowedOnline,
            ItemTransactionType? transactionType,
            ItemReceiptType? receiptType,
            decimal? smallestUnitCost,
            int? catagoryId,
            int? brandId,
            int? productGroupId,
            int? countryOfOriginId,
            Guid? mainTaxId,
            Guid? subTaxId)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            if (!string.IsNullOrWhiteSpace(englishName))
                EnglishName = englishName;



            if (isActive.HasValue)
                IsActive = isActive.Value;

            if (isAllowedOnline.HasValue)
                IsAllowedOnline = isAllowedOnline.Value;

            if (transactionType.HasValue)
                TransactionType = transactionType.Value;

            if (receiptType.HasValue)
                ReceiptType = receiptType.Value;

            if (smallestUnitCost.HasValue)
                SmallestUnitCost = smallestUnitCost.Value;

            if (catagoryId.HasValue)
                CatagoryId = catagoryId.Value;

            if (brandId.HasValue)
                BrandId = brandId.Value;

            if (productGroupId.HasValue)
                ProductGroupId = productGroupId.Value;

            if (countryOfOriginId.HasValue)
                CountryOfOriginId = countryOfOriginId.Value;

            if (mainTaxId.HasValue)
                MainTaxId = mainTaxId;

            if (subTaxId.HasValue)
                SubTaxId = subTaxId;

            LastUpdate = DateTime.UtcNow;
        }

        private ProductItem(Guid deletedId)
        {
            Id = deletedId;
        }

        [JsonConstructor]
        private ProductItem(
            [JsonProperty("id")] Guid id,
            [JsonProperty("name")] string name,
            [JsonProperty("englishName")] string englishName,
            [JsonProperty("isActive")] bool isActive,
            [JsonProperty("isAllowedOnline")] bool isAllowedOnline,
            [JsonProperty("transactionType")] ItemTransactionType transactionType,
            [JsonProperty("receiptType")] ItemReceiptType receiptType,
            [JsonProperty("smallestUnitCost")] decimal smallestUnitCost,
            [JsonProperty("catagoryId")] int catagoryId,
            [JsonProperty("brandId")] int brandId,
            [JsonProperty("productGroupId")] int productGroupId,
            [JsonProperty("countryOfOriginId")] int countryOfOriginId,
            [JsonProperty("mainTaxId")] Guid? mainTaxId,
            [JsonProperty("subTaxId")] Guid? subTaxId,
            [JsonProperty("createdAt")] DateTime createdAt,
            [JsonProperty("lastUpdate")] DateTime? lastUpdate = null)

        {
            Id = id;
            Name = name;
            EnglishName = englishName;
            IsActive = isActive;
            IsAllowedOnline = isAllowedOnline;
            TransactionType = transactionType;
            ReceiptType = receiptType;
            SmallestUnitCost = smallestUnitCost;
            CatagoryId = catagoryId;
            BrandId = brandId;
            ProductGroupId = productGroupId;
            CountryOfOriginId = countryOfOriginId;
            MainTaxId = mainTaxId;
            SubTaxId = subTaxId;
            CreatedAt = createdAt;
            LastUpdate = lastUpdate;
        }

        public static ProductItem CreateForDelete(Guid id)
        {
            return new ProductItem(id);
        }
    }




}
