using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.ProductsData;
using Product.Application.Common.Helpers;
using Product.Application.Common.Interfaces;
using Product.Domain.Common;
using Product.Domain.Products;


namespace Product.Application.Queries.Products.GetProductsHistory
{
    public class GetProductsHistoryQueryHandler
        (IAuditLogRepository _productRepository)
        : IRequestHandler<GetProductHistoryQuery, OutcomeOf<IEnumerable<ProductHistoryData>>>
    {

        public async Task<OutcomeOf<IEnumerable<ProductHistoryData>>> Handle(GetProductHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productHistory = await _productRepository.GetHistoryAsync(
                    entityName: DomainModelsNames.ProductItemName,
                    entityId: request.Id.ToString(),
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum,
                    includeAdded: request.IncludeAdds,
                    includeUpdated: request.IncludeUpdates,
                    includeDeleted: request.IncludeDeletes);


                if (productHistory == null || !productHistory.Any())
                {
                    return Error.NotFound(description: "No history found for the specified product ID.");
                }


                var productsList = new List<ProductHistoryData>();
                foreach (var item in productHistory)
                {
                    if (item.OldValues != null)
                    {
                        var oldProduct = item.OldValues.Deserialize<ProductItem>();
                        if (oldProduct != null)
                        {
                            productsList.Add(new ProductHistoryData(oldProduct,item.Date,item.Action));
                        }
                    }
                }

                return productsList;
            }
            catch (Exception ex)
            {
                return Error.Failure(description: "An error occurred while retrieving the product history.\n"+ex.Message);
            }
        }
    }
}
