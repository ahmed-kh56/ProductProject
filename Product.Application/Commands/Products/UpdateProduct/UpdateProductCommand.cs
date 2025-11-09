using MediatR;
using OutcomeOf;
using Product.Domain.Products;


namespace Product.Application.Commands.Products.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string? Name,
        string? EnglishName,
        bool? IsActive,
        bool? IsAllowedOnline,
        ItemTransactionType? TransactionType,
        ItemReceiptType? ReceiptType,
        decimal? SmallestUnitCost,
        int? CatagoryId,
        int? BrandId,
        int? ProductGroupId,
        int? CountryOfOriginId,
        Guid? MainTaxId,
        Guid? SubTaxId
    ) : IRequest<OutcomeOf<Done>>;



}
