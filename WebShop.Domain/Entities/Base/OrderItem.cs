using System.ComponentModel.DataAnnotations;

namespace WebShop.Domain.Entities.Base
{
    public class OrderItem : BaseEntity
    {
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
