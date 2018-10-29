using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.Dto.Product;
using WebShop.Domain.Entities;
using WebShop.Domain.Filters;
using WebShop.Interfaces;

namespace WebShop.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _productData;

        public ProductsApiController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpGet("brands/{id}")]
        public BrandDto GetBrandById(int id)
        {
            return _productData.GetBrandById(id);
        }

        [HttpGet("brands")]
        public IEnumerable<BrandDto> GetBrands()
        {
            return _productData.GetBrands();
        }

        [HttpGet("{id}")]
        public ProductDto GetProductById(int id)
        {
            return _productData.GetProductById(id);        
        }

        [HttpPost]
        public IEnumerable<ProductDto> GetProducts([FromBody]ProiductFilter filter)
        {
            return _productData.GetProducts(filter);
        }

        [HttpGet("sections/{id}")]
        public SectionDto GetSectionById(int id)
        {
            return _productData.GetSectionById(id);
        }

        [HttpGet("sections")]
        public IEnumerable<SectionDto> GetSections()
        {
            return _productData.GetSections();
        }
    }
}