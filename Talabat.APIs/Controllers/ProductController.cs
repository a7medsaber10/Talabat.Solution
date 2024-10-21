using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.ProductSpecifications;

namespace Talabat.APIs.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IGenericRepository<ProductBrand> _brandRepository;
        private readonly IGenericRepository<ProductCategory> _categoryRepository;
        private readonly IMapper _mapper;

        public ProductController(
            IGenericRepository<Product> repository,
            IGenericRepository<ProductBrand> brandRepository,
            IGenericRepository<ProductCategory> categoryRepository,
            IMapper mapper
            )
        {
            _repository = repository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts([FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(specParams);

            var products = await _repository.GetAllWithSpecAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);

            var countSpec = new ProductWithFilterationForCountSpec(specParams);

            var count = await _repository.GetCountAsync(countSpec);

            return Ok(new Pagination<ProductDTO>(specParams.PageSize, specParams.PageIndex, data, count));
        }

        [ProducesResponseType(typeof(ProductDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product =  await _repository.GetWithSpecAsync(spec);
            if (product == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok(_mapper.Map<Product, ProductDTO>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await _brandRepository.GetAllAsync();
            return Ok(brands);
        }


        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

    }
}
