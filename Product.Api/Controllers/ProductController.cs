using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Requestes;
using Product.Application.Commands.Products.DeleteProduct;
using Product.Application.Queries.Products.GetAllProducts;
using Product.Application.Queries.Products.GetProductData;
using Product.Application.Queries.Products.GetProductsHistory;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly ISender _sender;
        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
            var result = await _sender.Send(query);
            return result.Match(
                products => Ok(products),
                error => Problem(error));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductDataQuery(id);
            var result = await _sender.Send(query);
            return result.Match(
                product => Ok(product),
                error => Problem(error));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            var command = request.ToCreateCommand();
            var result = await _sender.Send(command);
            return result.Match(
                productId => Ok(productId),
                error => Problem(error));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(
            Guid id,
            [FromBody] ProductRequest request)
        {
            var command = request.ToUpdateCommand(id);
            var result = await _sender.Send(command);
            return result.Match(
                product => Ok(product),
                error => Problem(error));
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _sender.Send(command);
            return result.Match(
                product => Ok(product),
                error => Problem(error));
        }


        [HttpGet("History")]
        public async Task<IActionResult> GetProductHistoryById(
            [FromQuery] Guid? id,
            [FromQuery] HistoriesRequest request)
        {
            var query = request.ToGetProductHistoryQuery(id);
            var result = await _sender.Send(query);
            return result.Match(
                product => Ok(product),
                error => Problem(error));
        }

        [HttpGet("Supplayers")]
        public async Task<IActionResult> GetProductSupplayers(
            [FromQuery] GetProductSupplayersRequest request,
            [FromQuery] Guid? id)

        {
            var query = request.ToQuery(id);
            var result = await _sender.Send(query);
            return result.Match(
                sp => Ok(sp),
                error => Problem(error));
        }

    }
}
