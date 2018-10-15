using System.Collections.Generic;
using WebShop.Domain.Models.Order;

namespace WebShop.Domain.Dto.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
