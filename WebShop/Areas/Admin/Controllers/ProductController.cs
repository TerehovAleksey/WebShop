using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebShop.Areas.Admin.ViewModels;
using WebShop.DAL;
using WebShop.Domain;
using WebShop.Domain.Entities;
using WebShop.Domain.Filters;
using WebShop.Interfaces;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Constants.Roles.Administrator)]
    public class ProductController : Controller
    {
        private readonly IProductData _productData;
        private readonly WebShopContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public ProductController(IProductData productData, IHostingEnvironment appEnvironment, WebShopContext context)
        {
            _productData = productData;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = _productData.GetProducts(new ProiductFilter());
            return View(products);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productData.GetProductById(id);

            ViewBag.Sections = _productData.GetSections();
            ViewBag.Brands = _productData.GetBrands();

            var model = new ProductViewModel()
            {
                Id = product.Id,
                Brand = product.Brand.Name,
                //Section = product.Section.Name,
                Name = product.Name,
                Price = product.Price,
                ImagePath = product.ImageUrl
            };
            return View("New", model);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.Sections = _productData.GetSections();
            ViewBag.Brands = _productData.GetBrands();
            var product = new ProductViewModel();
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    string pictureName = Path.GetFileName(model.Image.FileName);
                    string path = "/images/shop/" + pictureName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }
                }

                //добавление
                if (model.Id == 0)
                {
                    var product = new Product()
                    {
                        Name = model.Name,
                        Price = model.Price,
                        BrandId = _context.Brands.FirstOrDefault(x => x.Name.Equals(model.Brand)).Id,
                        SectionId = _context.Sections.FirstOrDefault(x => x.Name.Equals(model.Section)).Id,
                        Order = 0,
                        ImageUrl = model.Image != null ? Path.GetFileName(model.Image.FileName) : string.Empty
                    };
                    _context.Products.Add(product);                   
                }
                //редактирование
                else
                {
                    var product = _context.Products.FirstOrDefault(x => x.Id.Equals(model.Id));
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.BrandId = _context.Brands.FirstOrDefault(x => x.Name.Equals(model.Brand)).Id;
                    product.SectionId = _context.Sections.FirstOrDefault(x => x.Name.Equals(model.Section)).Id;
                    product.ImageUrl = model.Image != null ? Path.GetFileName(model.Image.FileName) : product.ImageUrl;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            ViewBag.Sections = _productData.GetSections();
            ViewBag.Brands = _productData.GetBrands();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _productData.GetProductById(id);
           // _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}