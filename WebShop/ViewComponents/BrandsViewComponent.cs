using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models.Products;

namespace WebShop.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public BrandsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }

        private IEnumerable<BrandViewModel> GetBrands()
        {
            var brands = _productData.GetBrands();
            return brands.Select(e => new BrandViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Order = e.Order,
                ProductsCount = 0
            }).OrderBy(e=>e.Order).ToList();
        }
    }
}
