using System.Collections.Generic;
using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString() => Name;
    }
}
