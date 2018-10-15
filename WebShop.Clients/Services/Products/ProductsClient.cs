using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using WebShop.Clients.Base;
using WebShop.Domain.Dto.Product;
using WebShop.Domain.Filters;
using WebShop.Interfaces;

namespace WebShop.Clients.Services.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration):base(configuration)
        {
            ServiceAddress = "api/products";
        }

        protected sealed override string ServiceAddress { get; set; }

        public IEnumerable<BrandDto> GetBrands()
        {
            var url = $"{ServiceAddress}/brands";
            var result = Get<List<BrandDto>>(url);
            return result;
        }

        public ProductDto GetProductById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<ProductDto>(url);
            return result;
        }

        public IEnumerable<ProductDto> GetProducts(ProiductFilter filter)
        {
            var url = $"{ServiceAddress}";
            var responce = Post(url, filter);
            var result = responce.Content.ReadAsAsync<IEnumerable<ProductDto>>().Result;
            return result;
        }

        public IEnumerable<SectionDto> GetSections()
        {
            var url = $"{ServiceAddress}/sections";
            var result = Get<List<SectionDto>>(url);
            return result;
        }
    }
}
