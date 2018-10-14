﻿using Microsoft.AspNetCore.Mvc;
using WebShop.Interfaces;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Order;

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
            _cartService.DecrementFromCard(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCard(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll(int id)
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCard(id);
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
                //var orderResult = _orderService.CreateOrder(model, User.Identity.Name);
                //_cartService.RemoveAll();
                //return RedirectToAction("OrderConfirmated", new { id = orderResult.Id });

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