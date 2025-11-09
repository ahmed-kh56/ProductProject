using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.ProductsData;


namespace Product.Application.Queries.Products.GetProductsHistory
{
    public record GetProductHistoryQuery(
        Guid? Id,
        int PageSize,
        int PageNum,
        bool IncludeUpdates,
        bool IncludeAdds,
        bool IncludeDeletes)
        :IRequest<OutcomeOf<IEnumerable<ProductHistoryData>>>;
}
