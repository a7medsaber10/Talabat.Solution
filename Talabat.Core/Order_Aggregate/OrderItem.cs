using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Order_Aggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(ProductItemOrdered productItem, decimal price, int quantity)
        {
            Product = productItem;
            Price = price;
            Quantity = quantity;
        }

        public OrderItem()
        {
                
        }

        public ProductItemOrdered Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
