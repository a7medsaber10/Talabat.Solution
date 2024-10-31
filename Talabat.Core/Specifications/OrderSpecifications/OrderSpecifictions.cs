using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Order_Aggregate;

namespace Talabat.Core.Specifications.OrderSpecifications
{
    public class OrderSpecifictions : BaseSpecifications<Order>
    {
        public OrderSpecifictions(string buyerEmail) : base(o => o.BuyerEmail == buyerEmail)
        {
            Includes.Add(o => o.DeliveryMethod);
            Includes.Add(o => o.Items);

            AddOrederBy(o => o.OrderDate);
        }
    }
}
