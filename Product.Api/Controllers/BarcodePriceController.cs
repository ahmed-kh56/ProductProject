using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Requestes;
using Product.Application.Commands.Prices.DeleteCustomPrice;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodePriceController : ApiController
    {
        private readonly ISender _sender;
        public BarcodePriceController(ISender sender)
        {
            _sender = sender;
        }


        #region Custom Price CRUD operations
        [HttpPost]
        public async Task<IActionResult> CreateCustomPrice([FromBody] CustomPriceRequest request)
        {
            var command = request.ToCreateCommand();
            var result = await _sender.Send(command);
            return result.Match(
                success => Ok(success),
                error => Problem(error));
        }

        [HttpPatch("{code}/{branchId}")]
        public async Task<IActionResult> UpdateCustomPrice(
            [FromRoute] string code,
            [FromBody] UpdateCustomPriceRequest request,
            [FromRoute] int branchId = 1)
        {
            var command = request.ToUpdateCommand(code, branchId);
            var result = await _sender.Send(command);
            return result.Match(
                success => Ok(success),
                error => Problem(error));
        }


        [HttpDelete("{code}/{branchId}")]
        public async Task<IActionResult> DeleteCustomPrice(
            [FromRoute] string code,
            [FromRoute] int branchId)
        {
            var command = new DeletePriceCommand(code, branchId);
            var result = await _sender.Send(command);
            return result.Match(
                success => Ok(success),
                error => Problem(error));
        }
        #endregion

        [HttpGet("history")]
        public async Task<IActionResult> GetPriceHistory(
            [FromQuery] string? code,
            [FromQuery] int? branchId,
            [FromQuery] HistoriesRequest request)
        {
            var query = request.ToGetPriceHistoryQuery(code, branchId);
            var result = await _sender.Send(query);
            return result.Match(
                priceHistories => Ok(priceHistories),
                error => Problem(error));
        }



    }
}
