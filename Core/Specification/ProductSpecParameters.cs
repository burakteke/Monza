using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductSpecParameters
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _PageSize { get; set; } = 6;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }
        private string? _Search { get; set; }
        public string Search 
        { 
            get => _Search;
            set => _Search = value.ToLower();
        }
    }
}