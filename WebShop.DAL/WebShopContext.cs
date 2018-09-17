﻿using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;

namespace WebShop.DAL
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
