using System.Collections.Generic;

namespace WebShop.Domain.Models.Products
{
    public class SectionCompleteViewModel
    {
        public IEnumerable<SectionVewModel> Sections { get; set; }

        public int? CurrentParrentSectionId { get; set; }

        public int? CurrentSectionId { get; set; }
    }
}
