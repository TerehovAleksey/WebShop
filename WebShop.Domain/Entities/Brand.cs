using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
