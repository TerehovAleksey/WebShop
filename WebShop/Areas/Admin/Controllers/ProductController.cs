using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain;
using WebShop.Domain.Filters;
using WebShop.Infrastructure.Interfaces;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Constants.Roles.Administrator)]
    public class ProductController : Controller
    {
        private readonly IProductData _productData;

        public ProductController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult List()
        {
            var products = _productData.GetProducts(new ProiductFilter());
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = _productData.GetProductById(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.Sections = _productData.GetSections();
            return View();
        }
    }
}