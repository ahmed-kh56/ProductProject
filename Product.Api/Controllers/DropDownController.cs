using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Queries.DropDowns.GetBranches;
using Product.Application.Queries.DropDowns.GetBrands;
using Product.Application.Queries.DropDowns.GetCatagories;
using Product.Application.Queries.DropDowns.GetCountries;
using Product.Application.Queries.DropDowns.GetGroup;
using Product.Application.Queries.DropDowns.GetTaxes;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ApiController
    {
        private readonly ISender sender;

        public DropDownController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCatagoriesDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }
        [HttpGet("Brands")]
        public async Task<IActionResult> GetBrands()
        {
            var query = new GetBrandDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }
        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            var query = new GetCountriesDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }


        // has to be reimplemented
        [HttpGet("Taxes")]
        public async Task<IActionResult> GetTaxes([FromQuery] string? taxType = null)
        {
            var query = new GetTaxesDropDownQuery(taxType);
            var result = await sender.Send(query);
            return result.Match(
                catagories => Ok(catagories),
                error => Problem(error)
            );
        }
        [HttpGet("Groups")]
        public async Task<IActionResult> GetGroups()
        {
            var query = new GetGroupDropDownQuery();
            var result = await sender.Send(query);
            return result.Match(
                g => Ok(g),
                error => Problem(error));
        }

        [HttpGet("Branchs")]
        public async Task<IActionResult> GetBranchs()
        {
            var query = new GetBranchesQuery();
            var result = await sender.Send(query);
            return result.Match(
                success => Ok(success),
                error => Problem(error));
        }

    }
}
