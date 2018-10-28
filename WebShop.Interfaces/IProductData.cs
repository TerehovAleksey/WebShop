using System.Collections.Generic;
using WebShop.Domain.Dto.Product;
using WebShop.Domain.Entities;
using WebShop.Domain.Filters;

namespace WebShop.Interfaces
{
    /// <summary>
    /// интерфейс для работы с товарами
    /// </summary>
    public interface IProductData
    {
        /// <summary>
        /// список секций
        /// </summary>
        /// <returns></returns>
        IEnumerable<SectionDto> GetSections();

        /// <summary>
        /// список брендов
        /// </summary>
        /// <returns></returns>
        IEnumerable<BrandDto> GetBrands();

        /// <summary>
        /// список продуктов
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<ProductDto> GetProducts(ProiductFilter filter);

        /// <summary>
        /// продукт по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDto GetProductById(int id);
    }
}
