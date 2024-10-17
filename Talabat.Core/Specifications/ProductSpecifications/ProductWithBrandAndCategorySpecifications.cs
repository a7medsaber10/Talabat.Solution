using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecifications
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(string sort) : base()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "price":
                        AddOrederBy(p  => p.Price);
                        break;
                    case "priceDesc":
                        AddOrederByDesc(p => p.Price);
                        break;
                    default:
                        AddOrederBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrederBy(p => p.Name);
            }
        }

        public ProductWithBrandAndCategorySpecifications(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
