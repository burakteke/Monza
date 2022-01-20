using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>())
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));
        }
    }
}