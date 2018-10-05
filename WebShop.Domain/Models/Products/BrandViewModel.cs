using System.Collections.Generic;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Models.Products
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ProductsCount { get; set; }
        public int Order { get; set; }
    }
}
