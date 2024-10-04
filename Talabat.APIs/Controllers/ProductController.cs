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
    }
}
