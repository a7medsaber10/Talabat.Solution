using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public Order(string buyerEmail, OrderStatus status , Address shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            Status = status;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subtotal;
        }

        public Order()
        {
            
        }

        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;

        public OrderStatus Status { get; set; }

        public Address ShippingAddress { get; set; }

        public int? DeliveryMethodId { get; set; }

        public DeliveryMethod? DeliveryMethod { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public decimal SubTotal { get; set; }    // orderItem * Quantity

        public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;

        public string PaymentIntendId { get; set; }
    }
}
