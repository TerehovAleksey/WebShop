﻿using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ErrorStatus(string id)
        {
            if (id == "404")
            {
                return RedirectToAction("PageNotFound");
            }
            return Content($"Статусный код ошибки: {id}");
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}