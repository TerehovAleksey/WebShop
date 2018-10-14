using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Dto.Product
{
    public class BrandDto : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
