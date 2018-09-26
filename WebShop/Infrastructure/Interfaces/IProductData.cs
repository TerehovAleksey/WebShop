using System.Collections.Generic;
using WebShop.Domain.Entities;
using WebShop.Domain.Filters;

namespace WebShop.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProiductFilter filter);
        Product GetProductById(int id);
    }
}
