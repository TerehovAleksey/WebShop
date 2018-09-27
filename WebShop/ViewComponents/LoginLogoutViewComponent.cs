using System;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}