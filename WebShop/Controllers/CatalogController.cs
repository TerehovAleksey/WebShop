using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.Entities;
using WebShop.Interfaces;
using WebShop.Domain.Models.Products;

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
                Products = products.Select(e => new ProductViewModel()
                {
                    Id = e.Id,
                    ImageUrl = e.ImageUrl,
                    Name = e.Name,
                    Order = e.Order,
                    Price = e.Price,
                    Brand = e.Brand.Name != null ? e.Brand.Name : string.Empty
                })
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productData.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                Brand = product.Brand != null ? product.Brand.Name : string.Empty
            });
        }
    }
}