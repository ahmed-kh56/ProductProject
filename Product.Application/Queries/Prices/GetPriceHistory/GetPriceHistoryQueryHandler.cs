using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Prices;
using Product.Application.Common.Helpers;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;
using Product.Domain.Common;

namespace Product.Application.Queries.Prices.GetPriceHistory
{
    public class GetPriceHistoryQueryHandler
        (IAuditLogRepository _auditLogRepository):IRequestHandler<GetPriceHistoryQuery, OutcomeOf<IEnumerable<PriceHistryData>>>
    {

        public async Task<OutcomeOf<IEnumerable<PriceHistryData>>> Handle(GetPriceHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var logs = await _auditLogRepository.GetHistoryAsync(
                    entityName: DomainModelsNames.PriceAccordingToBranchName,
                    entityId: request.Barcode is null
                    ? null
                    : $"{request.Barcode}-{request.BranchId.ToString() ?? ""}",
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum,
                    includeAdded: request.IncludeAdds,
                    includeUpdated: request.IncludeUpdates,
                    includeDeleted: request.IncludeDeletes);

                if (!logs.Any())
                    return Error.NotFound(
                        description: $"No history found for the BarcodePrice '{request.Barcode}' in that branch '{request.BranchId.ToString()??""}'",
                        code: "BarcodeHistoryNotFound");


                var result = new List<PriceHistryData>();
                foreach (var log in logs)
                {
                    if (log.Action == "Added")
                    {
                        result.Add(new PriceHistryData(
                            price: null,
                            ChangedAt: log.Date,
                            action: log.Action));
                    }
                    else
                    {
                        result.Add(new PriceHistryData(
                            log.Date,
                            log.Action,
                            log.OldValues.Deserialize<PriceAccordingToBranch>()));

                    }
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                return Error.Failure(
                    description: 
                    $"An error occurred while retrieving history for" +
                    $" barcodePrice '{request.Barcode +"-"+request.BranchId.ToString()??""}': {ex.Message}",
                    code: "BarcodePriceHistoryRetrievalError");
            }



        }
    }
}
