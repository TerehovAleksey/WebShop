using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebShop.Interfaces;

namespace WebShop.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartService.TransformCart();
            ViewBag.Count = cart.ItemsCount.ToString();
            ViewBag.Price = cart.Items.Sum(x => x.Key.Price * x.Value).ToString("C");
            return View();
        }
    }
}
