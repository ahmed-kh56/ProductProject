using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.Barcodes;
using Product.Application.Common.Helpers;
using Product.Application.Common.Interfaces;
using Product.Domain.Barcodes;
using Product.Domain.Common;

namespace Product.Application.Queries.Barcodes.GetDeletedBarcodes
{
    public class GetDeletedBarcodesQueryHandler
        (IAuditLogRepository _logRepository): IRequestHandler<GetDeletedBarcodesQuery, OutcomeOf<IEnumerable<BarcodeHistoryData>>>
    {

        public async Task<OutcomeOf<IEnumerable<BarcodeHistoryData>>> Handle(GetDeletedBarcodesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var barcodes = await _logRepository.GetHistoryAsync(
                    entityName: DomainModelsNames.BarcodeName,
                    includeAdded: false,
                    includeUpdated: false,
                    includeDeleted: true);
                if (!barcodes.Any())
                    return Error.NotFound(
                        description: "No deleted barcodes found",
                        code: "DeletedBarcodesNotFound");

                var result = new List<BarcodeHistoryData>();

                foreach (var log in barcodes)
                {
                    if (log.Action == "Added")
                        continue;
                    result.Add(new BarcodeHistoryData(
                        barcode: log.OldValues.Deserialize<Barcode>(),
                        ChangedAt: log.Date,
                        action: log.Action
                        ));
                }
                return result.ToList();
            }
            catch(Exception ex)
            {
                return Error.Failure(
                    description: $"An error occurred while retrieving deleted barcodes. {ex.Message}",
                    code: "GetDeletedBarcodesError");
            }
        }
    }


}
