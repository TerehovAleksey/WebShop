using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}
