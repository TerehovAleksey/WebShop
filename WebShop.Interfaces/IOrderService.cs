using System.Collections.Generic;
using WebShop.Domain.Dto.Order;

namespace WebShop.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetUserOrders(string userName);
        OrderDto GetOrderById(int id);
        OrderDto CreateOrder(CreateOrderModel orderModel, string userName);
    }
}
