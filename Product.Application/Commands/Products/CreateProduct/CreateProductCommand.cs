using MediatR;
using OutcomeOf;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Commands.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string EnglishName,
        bool IsActive,
        bool IsAllowedOnline,
        ItemTransactionType TransactionType,
        ItemReceiptType ReceiptType,
        decimal SmallestUnitCost,
        int CatagoryId,
        int BrandId,
        int ProductGroupId,
        int CountryOfOriginId,
        Guid? MainTaxId,
        Guid? SubTaxId
    ) : IRequest<OutcomeOf<Guid>>;




}


