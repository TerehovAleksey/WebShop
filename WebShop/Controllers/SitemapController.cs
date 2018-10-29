using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using WebShop.Interfaces;

namespace WebShop.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IProductData _productData;

        public SitemapController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Index()
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index", "Home")),
                new SitemapNode(Url.Action("Shop", "Catalog")),
                new SitemapNode(Url.Action("BlogSingle", "Home")),
                new SitemapNode(Url.Action("Blog", "Home")),
                new SitemapNode(Url.Action("ContactUs", "Home")),
            };

            var sections = _productData.GetSections();
            foreach (var item in sections)
            {
                if (item.ParentId.HasValue)
                {
                    nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog", new { sectionId = item.Id })));
                }
            }

            var brands = _productData.GetBrands();
            foreach (var item in brands)
            {
                nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog", new { brandId = item.Id })));
            }

            var products = _productData.GetProducts(new Domain.Filters.ProiductFilter());
            foreach (var item in products)
            {
                nodes.Add(new SitemapNode(Url.Action("ProductDetails", "Catalog", new { id = item.Id })));
            }

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}