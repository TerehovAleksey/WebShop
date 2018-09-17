using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models.Products;

namespace WebShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;

        public CatalogController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Shop(int? sectionId, int? brandId)
        {
            var products = _productData.GetProducts(new Domain.Filters.ProiductFilter() { SectionId = sectionId, BrandId = brandId });
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = products.Select(e=>new ProductViewModel()
                {
                    Id = e.Id,
                    ImageUrl = e.ImageUrl,
                    Name = e.Name,
                    Order = e.Order,
                    Price = e.Price
                })
            };

            return View(model);
        }

        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}