using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Requestes;
using Product.Application.Commands.Barcodes.DeleteBarcode;
using Product.Application.Queries.Barcodes.GetBarcodeHistory;
using Product.Application.Queries.Barcodes.GetDeletedBarcodes;
using Product.Application.Queries.Barcodes.GetProductBarcodes;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ApiController
    {

        private readonly ISender _sender;
        public BarcodeController(ISender sender)
        {
            _sender = sender;
        }


        #region Barcode default CRUD oprations
        [HttpGet]
        public async Task<IActionResult> GetBarcodesForProduct(
            [FromQuery] Guid productId,
            [FromQuery] int branchId = 0)
        {
            var query = new GetBarcodesByProductIdQuery(productId, branchId);
            var result = await _sender.Send(query);
            return result.Match(
                succ => Ok(succ),
                error => Problem(error));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductBarcode(
            [FromQuery] Guid productId,
            [FromBody] BarcodeRequest request)
        {
            var query = request.ToCreateCommand(productId);
            var result = await _sender.Send(query);
            return result.Match(
                succ => Ok(succ),
                error => Problem(error));
        }
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateProductBarcode(
            string code,
            [FromBody] UpdateBarcodeRequest request)
        {
            var query = request.ToUpdateCommand(code);
            var result = await _sender.Send(query);
            return result.Match(
                succ => Ok(succ),
                error => Problem(error));
        }


        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProductBarcode(
            string code)
        {
            var query = new DeleteBarcodeCommand(code);
            var result = await _sender.Send(query);
            return result.Match(
                succ => Ok(succ),
                error => Problem(error));
        }

        #endregion




        #region   Barcode History
        [HttpGet("{code}/History")]
        public async Task<IActionResult> GetBarcodeHistory(
            string code,
            [FromQuery] HistoriesRequest request)
        {
            var query = request.ToGetBarcodeHistoryQuery(code);
            var result = await _sender.Send(query);
            return result.Match(
                succ => Ok(succ),
                error => Problem(error));

        }
        [HttpGet("History/Deleted")]
        public async Task<IActionResult> GetAllDeletedBarcodeHistory()
        {
            var query = new GetDeletedBarcodesQuery();
            var result = await _sender.Send(query);
            return result.Match(
                succ => Ok(succ),
                error => Problem(error));

        }
        #endregion



    }
}
