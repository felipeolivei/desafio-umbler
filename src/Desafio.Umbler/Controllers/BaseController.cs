using Desafio.Umbler.Response;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Umbler.Controllers
{
    [Route("api")]
    public class BaseController : Controller
    {
        [NonAction]
        public virtual NotFoundObjectResult NotFound(string message, object error)
        {
            return new NotFoundObjectResult(new ApiResponseObject()
            {
                Result = null,
                Success = false,
                Error = new ErrorObject()
                {
                    Message = message,
                    Details = error
                }
            });
        }

        [NonAction]
        public virtual NotFoundObjectResult NotFound()
        {
            return NotFound("NotFound", null);
        }

        [NonAction]
        public virtual OkObjectResult Success()
        {
            return Success(Ok());
        }

        [NonAction]
        public virtual OkObjectResult Success(object result)
        {
            return Ok(new ApiResponseObject()
            {
                Success = true,
                Result = result,
                Error = null,
            });
        }

        [NonAction]
        public virtual BadRequestObjectResult Error(string message, object error)
        {
            return BadRequest(new ApiResponseObject()
            {
                Success = false,
                Result = null,
                Error = new ErrorObject()
                {
                    Message = message,
                    Details = error
                }
            });
        }
    }
}
