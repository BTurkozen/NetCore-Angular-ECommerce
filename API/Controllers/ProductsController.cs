using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification();

            var data = await _productRepository.ListAsync(spec);
            //return data.Select(pro => new ProductToReturnDto
            //{
            //    Id = pro.Id,
            //    Name = pro.Name,
            //    Description = pro.Description,
            //    PictureUrl = pro.PictureUrl,
            //    Price = pro.Price,
            //    ProductType = pro.ProductType != null ? pro.ProductType.Name : string.Empty,
            //    ProductBrand = pro.ProductBrand != null ? pro.ProductBrand.Name : string.Empty
            //}).ToList();

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(data));

            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);

            var product = await _productRepository.GetEntityWithSpec(spec);
            //return new ProductToReturnDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductType = product.ProductType != null? product.ProductType.Name : string.Empty,
            //    ProductBrand = product.ProductBrand != null ? product.ProductBrand.Name : string.Empty
            //};

            //Yukarıdaki işlemin yerine mapper kullanarak yapıcaz işlemlerimizi.

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {

            return Ok(await _productBrandRepository.ListAllAsync());
        }
    }
}
