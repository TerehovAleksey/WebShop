using System;
using System.Collections.Generic;
using WebShop.Domain.Entities.Base;

namespace WebShop.Domain.Dto.Order
{
    public class OrderDto : NamedEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
