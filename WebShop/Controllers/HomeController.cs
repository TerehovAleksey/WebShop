using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Interfaces.Api;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValuesService _valuesCervice;

        public HomeController(IValuesService valuesCervice)
        {
            _valuesCervice = valuesCervice;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _valuesCervice.GetAsync();
            return View(values);
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}