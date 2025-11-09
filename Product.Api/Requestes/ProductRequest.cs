using Product.Application.Commands.Products.CreateProduct;
using Product.Application.Commands.Products.UpdateProduct;
using Product.Domain.Products;
namespace Product.Api.Requestes
{
    public class ProductRequest
    {
        public string? Name { get; set; }
        public string? EnglishName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAllowedOnline { get; set; }
        public ItemTransactionType? TransactionType { get; set; }
        public ItemReceiptType? ReceiptType { get; set; }
        public decimal? SmallestUnitCost { get; set; }
        public int? CatagoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? CountryOfOriginId { get; set; }
        public Guid? MainTaxId { get; set; }
        public Guid? SubTaxId { get; set; }

        public CreateProductCommand ToCreateCommand()
            => new(
                Name!,
                EnglishName!,
                IsActive ?? true,
                IsAllowedOnline ?? false,
                TransactionType ?? ItemTransactionType.Ordered,
                ReceiptType ?? ItemReceiptType.Request,
                SmallestUnitCost ?? 0,
                CatagoryId ?? default,
                BrandId ?? default,
                ProductGroupId ?? default,
                CountryOfOriginId ?? default,
                MainTaxId,
                SubTaxId
            );

        public UpdateProductCommand ToUpdateCommand(Guid id)
            => new(
                id,
                Name,
                EnglishName,
                IsActive,
                IsAllowedOnline,
                TransactionType,
                ReceiptType,
                SmallestUnitCost,
                CatagoryId,
                BrandId,
                ProductGroupId,
                CountryOfOriginId,
                MainTaxId,
                SubTaxId
            );
    }



}


