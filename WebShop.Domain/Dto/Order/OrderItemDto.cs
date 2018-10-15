using WebShop.Domain.Entities.Base;

namespace WebShop.Domain.Dto.Order
{
    public class OrderItemDto : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
