using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Domain.Entities;
using WebShop.Domain.Entities.Base;
using WebShop.Interfaces;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Order;
using WebShop.DAL;
using WebShop.Domain.Dto.Order;

namespace WebShop.Services.Sql
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

        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
            return _context.Orders.Include("User").Include("OrderItems").Where(x => x.User.UserName.Equals(userName)).Select(x=>new OrderDto
            {
                Address = x.Address,
                Date = x.Date,
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                OrderItems = x.OrderItems.Select(i=>new OrderItemDto
                {
                    Id = i.Id,
                    Price = i.Price,
                    Quantity = i.Quantity
                })
            }).ToList();
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _context.Orders.Include("OrderItems").FirstOrDefault(x => x.Id.Equals(id));
            if (order == null)
                return null;
            return new OrderDto()
            {
                Address = order.Address,
                Date = order.Date,
                Id = order.Id,
                Name = order.Name,
                Phone = order.Phone,
                OrderItems = order.OrderItems.Select(i => new OrderItemDto()
                {
                    Id = i.Id,
                    Price = i.Price,
                    Quantity = i.Quantity
                })
            };
        }

        public OrderDto CreateOrder(CreateOrderModel orderModel, string userName)
        {
            ApplicationUser user = null;

            if (!string.IsNullOrEmpty(userName))
            {
                user = _userManager.FindByNameAsync(userName).Result;
            }
            
            using (var transaction = _context.Database.BeginTransaction())
            {
                var order = new Order()
                {
                    Address = orderModel.OrderViewModel.Address,
                    Name = orderModel.OrderViewModel.Name,
                    Date = DateTime.Now,
                    Phone = orderModel.OrderViewModel.Phone,
                    User = user
                };

                _context.Orders.Add(order);

                foreach (var item in orderModel.OrderItems)
                {
                    var product = _context.Products.FirstOrDefault(x => x.Id.Equals(item.Id));
                    if (product == null)
                        throw new InvalidOperationException("Продукт не найден в базе");
                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = item.Quantity,
                        Product = product
                    };
                    _context.OrderItems.Add(orderItem);
                }
                _context.SaveChanges();
                transaction.Commit();
                return GetOrderById(order.Id);
            }
        }
    }
}
