using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Order_Aggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered(int productid, string productname, string producturl)
        {
            ProductId = productid;
            ProductName = productname;
            ProductURL = producturl;
        }

        public ProductItemOrdered()
        {
            
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductURL { get; set; }
    }
}
