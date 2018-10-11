using System.Collections.Generic;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Models.Products
{
    public class SectionVewModel : INamedEntity, IOrderedEntity
    {
        public SectionVewModel()
        {
            ChildSection = new List<SectionVewModel>();
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }

        public List<SectionVewModel> ChildSection { get; set; }
        public SectionVewModel ParentSection { get; set; }
    }
}
