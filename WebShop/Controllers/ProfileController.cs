using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models.Order;

namespace WebShop.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IOrderService _orderService;

        public ProfileController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _orderService.GetUserOrders(User.Identity.Name);
            var orderModels = new List<UserOrderViewModel>(orders.Count());
            foreach (var item in orders)
            {
                orderModels.Add(new UserOrderViewModel()
                {
                    Id = item.Id,
                    Address = item.Address,
                    Name = item.Name,
                    Phone = item.Phone,
                    TotalSum = item.OrderItems.Sum(i => i.Price * i.Quantity)
                });
            }
            return View(orderModels);
        }
    }
}