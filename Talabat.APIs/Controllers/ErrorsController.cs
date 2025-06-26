using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;

namespace Talabat.APIs.Controllers
{
    [Route("Errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error(int code)
        {
            if (code == 404)
            {
                return NotFound(new APIResponse(404));
            }
            else if (code == 401)
            {
                return Unauthorized(new APIResponse(401));
            }
            else
            {
                return StatusCode(code);
            }
        }
    }
}
