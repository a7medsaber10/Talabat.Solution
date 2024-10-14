using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreContext _dbContext;

        public BuggyController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("notfound")] // Get : api/Buggy/notfound
        public ActionResult GetNotFoundRequest() 
        {
            var product = _dbContext.Products.Find(100);
            if (product == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok(product);
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _dbContext.Products.Find(100);
            var ProductDTO = product.ToString(); // null ref exception
            return Ok(ProductDTO);
        }

        [HttpGet("badrequest")] // Get : api/Buggy/badrequest
        public ActionResult GetBadRequestError() 
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnAuthorized()
        {
            return Unauthorized(new APIResponse(401));
        }

        [HttpGet("badrequest/{id}")] // Get : api/Buggy/badrequest/id
        public ActionResult GetBadRequetError(int id)
        {
            return Ok();  
        }
    }
}
