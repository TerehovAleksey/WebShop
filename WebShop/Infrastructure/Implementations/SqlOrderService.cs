using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.DAL;
using WebShop.Domain.Entities;
using WebShop.Domain.Entities.Base;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models.Cart;
using WebShop.Models.Order;

namespace WebShop.Infrastructure.Implementations
{
    public class SqlOrderService : IOrderService
    {
        private readonly WebShopContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SqlOrderService(WebShopContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            return _context.Orders.Include("User").Include("OrderItems").Where(x => x.User.UserName.Equals(userName)).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include("OrderItems").FirstOrDefault(x => x.Id.Equals(id));
        }

        public Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            using (var transaction = _context.Database.BeginTransaction())
            {
                var order = new Order()
                {
                    Address = orderModel.Address,
                    Name = orderModel.Name,
                    Date = DateTime.Now,
                    Phone = orderModel.Phone,
                    User = user
                };

                _context.Orders.Add(order);

                foreach (var item in transformCart.Items)
                {
                    var productVm = item.Key;
                    var product = _context.Products.FirstOrDefault(x => x.Id.Equals(productVm.Id));
                    if (product == null)
                        throw new InvalidOperationException("Продукт не найден в базе");
                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = item.Value,
                        Product = product
                    };
                    _context.OrderItems.Add(orderItem);
                }
                _context.SaveChanges();
                transaction.Commit();
                return order;
            }
        }
    }
}
