using System.Collections.Generic;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Interfaces
{
    interface IProductData
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
    }
}
