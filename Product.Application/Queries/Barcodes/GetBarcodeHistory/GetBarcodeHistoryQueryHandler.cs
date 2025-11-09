using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;
using Product.Application.Common.Helpers;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;
using Product.Domain.Common;

namespace Product.Application.Queries.Barcodes.GetBarcodeHistory
{
    public class GetBarcodeHistoryQueryHandler
        (IAuditLogRepository _logRepository) : IRequestHandler<GetBarcodeHistoryQuery, OutcomeOf<IEnumerable<BarcodeHistoryData>>>
    {

        public async Task<OutcomeOf<IEnumerable<BarcodeHistoryData>>> Handle(GetBarcodeHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var logs = await _logRepository.GetHistoryAsync(
                    entityName: DomainModelsNames.BarcodeName,
                    entityId: request.Barcode,
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum,
                    includeAdded:request.IncludeAdds,
                    includeUpdated:request.IncludeUpdates,
                    includeDeleted:request.IncludeDeletes);

                if (!logs.Any())
                    return Error.NotFound(
                        description: $"No history found for barcode '{request.Barcode}'",
                        code: "BarcodeHistoryNotFound");


                var result = new List<BarcodeHistoryData>();
                foreach (var log in logs)
                {
                    if (log.Action == "Added")
                    {
                        result.Add(new BarcodeHistoryData(
                            barcode: null,
                            ChangedAt: log.Date,
                            action: log.Action));
                    }
                    else
                    {
                        result.Add(new BarcodeHistoryData(
                            log.Date,
                            log.Action,
                            log.OldValues.Deserialize<Barcode>()));

                    }
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                return Error.Failure(
                    description: $"An error occurred while retrieving history for barcode '{request.Barcode}': {ex.Message}",
                    code: "BarcodeHistoryRetrievalError");
            }


        }
    }


}
