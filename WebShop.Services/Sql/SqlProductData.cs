﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebShop.DAL;
using WebShop.Domain.Dto.Product;
using WebShop.Domain.Entities;
using WebShop.Domain.Filters;
using WebShop.Interfaces;

namespace WebShop.Services.Sql
{
    public class SqlProductData : IProductData
    {
        private readonly WebShopContext _db;

        public SqlProductData(WebShopContext db)
        {
            _db = db;
        }

        public BrandDto GetBrandById(int id)
        {
            var brand = _db.Brands.FirstOrDefault(x => x.Id == id);
            if (brand != null)
            {
                return new BrandDto()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Order = brand.Order
                };
            }
            return null;
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            return _db.Brands.Select(x =>
                new BrandDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Order = x.Order
                }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            var product = _db.Products.Include("Brand").Include("Section").FirstOrDefault(x => x.Id.Equals(id));
            if (product == null)
            {
                return null;
            }

            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Order = product.Order,
                Price = product.Price,
                Section = new SectionDto() { Id = product.SectionId, Name = product.Section.Name },
            };
            if (product.Brand != null)
            {
                dto.Brand = new BrandDto()
                {
                    Name = product.Brand.Name,
                    Id = product.Brand.Id,
                    Order = product.Brand.Order
                };
            }
            return dto;
        }

        public IEnumerable<ProductDto> GetProducts(ProiductFilter filter)
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
            return query.Select(x => new ProductDto
            {
                Brand = x.BrandId.HasValue ? new BrandDto { Id = x.Brand.Id, Name = x.Brand.Name, Order = x.Brand.Order } : null,
                Section = new SectionDto() { Id = x.SectionId, Name = x.Section.Name },
                Id = x.Id,
                Order = x.Order,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToList();
        }

        public SectionDto GetSectionById(int id)
        {
            var section = _db.Sections.FirstOrDefault(x => x.Id == id);

            if (section != null)
            {
                return new SectionDto()
                {
                    Id = section.Id,
                    Name = section.Name,
                    Order = section.Order,
                    ParentId = section.ParentId
                };
            }
            return null;
        }

        public IEnumerable<SectionDto> GetSections()
        {
            return _db.Sections.Select(x => new SectionDto
            {
                Id = x.Id,
                Name = x.Name,
                Order = x.Order,
                ParentId = x.ParentId
            }).ToList();
        }
    }
}
