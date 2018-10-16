using System;
using System.Collections.ObjectModel;
using WebShop.Domain.Entities.Base;

namespace WebShop.Domain.Entities
{
    public class Order : NamedEntity
    {
        public virtual IDentityRole User { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        public virtual Collection<OrderItem> OrderItems { get; set; }
    }
}
