using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OutcomeOf;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {


        protected IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status403Forbidden,
                ErrorType.Failure => StatusCodes.Status424FailedDependency,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode, detail: error.Massage);
        }


    }
}
