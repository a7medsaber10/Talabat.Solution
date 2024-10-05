using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.APIs.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product =  await _repository.GetAsync(id);
            if (product == null)
            {
                return NotFound(new {Message = "Not Found", StatusCode = 404});
            }
            return Ok(product);
        }

    }
}
