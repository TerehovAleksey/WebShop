using Microsoft.AspNetCore.Mvc;
using WebShop.Interfaces;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Order;
using WebShop.Domain.Dto.Order;
using System.Collections.Generic;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        public IActionResult Details()
        {
            var model = new DetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };
            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll(int id)
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cart = _cartService.TransformCart();
                var items = new List<OrderItemDto>();
                foreach (var item in cart.Items)
                {
                    items.Add(new OrderItemDto()
                    {
                        Id = item.Key.Id,
                        Price = item.Key.Price,
                        Quantity = item.Value
                    });
                }

                CreateOrderModel order = new()
                {
                    OrderViewModel = model,
                    OrderItems = items
                };
                var orderResult = _orderService.CreateOrder(order, User.Identity.Name);
                _cartService.RemoveAll();
                return RedirectToAction("OrderConfirmated", new { id = orderResult.Id });

            }
            var detailsModel = new DetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };

            return View("Details", detailsModel);
        }

        public IActionResult OrderConfirmated(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}