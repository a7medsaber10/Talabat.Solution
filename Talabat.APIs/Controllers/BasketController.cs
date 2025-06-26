using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.APIs.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string Id)
        {
            var basket = await _repository.GetBasketAsync(Id);
            
            return Ok(basket ?? new CustomerBasket(Id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDTO basket)
        {
            var mappedBasket = _mapper.Map<CustomerBasketDTO, CustomerBasket>(basket);

            var createOrUpdateBasket = await _repository.UpdateBasketAsync(mappedBasket);

            if (createOrUpdateBasket is null)
            {
                return BadRequest(new APIResponse(400));
            }

            return Ok(createOrUpdateBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string Id)
        {
            await _repository.DeleteBasketAsync(Id);
        }
    }
}
