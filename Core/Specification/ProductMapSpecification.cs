using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductMapSpecification: BaseSpesification<Product>
    {
        public ProductMapSpecification(ProductSpecParameters prms)
        : base(x =>
            (string.IsNullOrEmpty(prms.Search) || x.Name.ToLower().Contains(prms.Search))
            && (!prms.BrandId.HasValue || x.ProductBrandId == prms.BrandId)
            && (!prms.TypeId.HasValue || x.ProductTypeId == prms.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(prms.PageSize*(prms.PageIndex - 1), prms.PageSize);
            if(!string.IsNullOrEmpty(prms.Sort))
            {
                switch(prms.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);            
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);            
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                };
            }
        }

        public ProductMapSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}