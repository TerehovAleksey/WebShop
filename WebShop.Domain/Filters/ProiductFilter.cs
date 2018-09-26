using System.Collections.Generic;

namespace WebShop.Domain.Filters
{
    public class ProiductFilter
    {
        public int? SectionId { get; set; }
        public int? BrandId { get; set; }
        public List<int> Ids { get; set; }
    }
}
