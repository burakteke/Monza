using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductMapSpecification: BaseSpesification<Product>
    {
        public ProductMapSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductMapSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}