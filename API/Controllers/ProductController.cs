using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Data;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        public IGenericRepository<Product> ProductRepo { get; }
        public IGenericRepository<ProductBrand> BrandRepo { get; }
        public IGenericRepository<ProductType> TypeRepo { get; }
        public IMapper Mapper { get; }

        public ProductController(IGenericRepository<Product> productRepo, 
            IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductType> typeRepo,
            IMapper mapper)
        {
            ProductRepo = productRepo;
            BrandRepo = brandRepo;
            TypeRepo = typeRepo;
            Mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductMapSpecification();
            var products = await ProductRepo.ListAsync(spec);
            return Ok(Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductMapSpecification(id);
            var product = await ProductRepo.GetEntityWithSpec(spec);
            return Mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> GetProductTypes()
        {
            var products = await TypeRepo.ListAllAsync();
            return Ok(products);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var products = await BrandRepo.ListAllAsync();
            return Ok(products);
        }


    }
}