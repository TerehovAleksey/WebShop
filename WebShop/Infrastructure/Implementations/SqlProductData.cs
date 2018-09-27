using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.DAL;
using WebShop.Domain.Entities;
using WebShop.Domain.Filters;
using WebShop.Infrastructure.Interfaces;

namespace WebShop.Infrastructure.Implementations
{
    public class SqlProductData : IProductData
    {
        private readonly WebShopContext _db;

        public SqlProductData(WebShopContext db)
        {
            _db = db;
        }

        public IEnumerable<Brand> GetBrands()
        {
           return _db.Brands.ToList();
        }

        public Product GetProductById(int id)
        {
            return _db.Products.Include("Brand").Include("Section").FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Product> GetProducts(ProiductFilter filter)
        {
            var query = _db.Products.Include("Brand").Include("Section").AsQueryable();

            if (filter.BrandId.HasValue)
            {
                query = query.Where(x => x.BrandId.HasValue && x.BrandId.Equals(filter.BrandId));
            }
            if (filter.SectionId.HasValue)
            {
                query = query.Where(x => x.SectionId.Equals(filter.SectionId));
            }
            return query.ToList();
        }

        public IEnumerable<Section> GetSections()
        {
            return _db.Sections.ToList();
        }
    }
}
