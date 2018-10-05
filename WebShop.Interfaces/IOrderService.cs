using System.Collections.Generic;
using WebShop.Domain.Entities;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Order;

namespace WebShop.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetUserOrders(string userName);
        Order GetOrderById(int id);
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);
    }
}
