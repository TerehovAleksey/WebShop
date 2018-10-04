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
        public IActionResult Index()
        {
            return View();
        }
    }
}