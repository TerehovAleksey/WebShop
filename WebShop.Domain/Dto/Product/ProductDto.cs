using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Dto.Product
{
    public class ProductDto : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public BrandDto Brand { get; set; }
        public SectionDto Section { get; set; }
    }
}
