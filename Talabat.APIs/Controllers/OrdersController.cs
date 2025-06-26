using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Order_Aggregate;
using Talabat.Core.Services.Contract;

namespace Talabat.APIs.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTO>> CreateOrder(OrderDTO orderDTO)
        {
            var address = _mapper.Map<AddressDTO, Address>(orderDTO.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(orderDTO.BuyerEmail, orderDTO.BasketId, orderDTO.DeliveryMethodId, address);

            if (order is null) { return BadRequest(new APIResponse(400)); }
            return Ok(_mapper.Map<Order, OrderToReturnDTO>(order));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDTO>>> GetOrdersForUserAsync(string email)
        {
            var orders = await _orderService.GetOrdersForUserAsync(email);
            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDTO>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDTO>> GetOrderByIdForUser(int id, string email)
        {
            var order = await _orderService.GetOrderByIdForUserAsync(id, email);
            if(order is null) return NotFound(new APIResponse(404));
            return Ok(_mapper.Map<Order, OrderToReturnDTO>(order));
        }
    }
}
