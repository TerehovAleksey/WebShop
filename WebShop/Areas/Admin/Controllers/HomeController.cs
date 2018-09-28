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
    public class HomeController : Controller
    {
        private readonly IProductData _productData;

        public HomeController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = _productData.GetProducts(new ProiductFilter());
            return View(products);
        }
    }
}