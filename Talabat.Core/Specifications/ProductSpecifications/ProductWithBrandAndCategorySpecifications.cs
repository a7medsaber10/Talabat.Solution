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
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams specParams) : base
            (
                p => 
                (!specParams.BrandId.HasValue || p.BrandId == specParams.BrandId.Value) 
                && 
                (!specParams.CategoryId.HasValue || p.CategoryId == specParams.CategoryId.Value)
            )
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

            if(!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
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

            ApplyPagination((specParams.PageIndex -1) * specParams.PageSize, specParams.PageSize);
        }

        public ProductWithBrandAndCategorySpecifications(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
