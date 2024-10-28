using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Order_Aggregate;
using Talabat.Core.Services.Contract;

namespace Talabat.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int DeliveryMethod, Address shippingAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
