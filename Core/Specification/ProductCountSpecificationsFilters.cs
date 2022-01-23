using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductCountSpecificationsFilters: BaseSpesification<Product>
    {
        public ProductCountSpecificationsFilters(ProductSpecParameters prms)
        : base(x =>
            (string.IsNullOrEmpty(prms.Search) || x.Name.ToLower().Contains(prms.Search))
            && (!prms.BrandId.HasValue || x.ProductBrandId == prms.BrandId)
            && (!prms.TypeId.HasValue || x.ProductTypeId == prms.TypeId)
            )
        {
            
        }
    }
}