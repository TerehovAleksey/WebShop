using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models.Products;

namespace WebShop.ViewComponents
{
    public class SectionViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public SectionViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sections = GetSections();
            return View(sections);
        }

        private List<SectionVewModel> GetSections()
        {
            var categories = _productData.GetSections();
            var parentCategories = categories.Where(e => !e.ParentId.HasValue).ToArray();
            var parentSections = new List<SectionVewModel>();
            foreach (var item in parentCategories)
            {
                parentSections.Add(new SectionVewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Order = item.Order,
                    ParentSection = null
                });
            }

            foreach (var section in parentSections)
            {
                var childCategories = categories.Where(e => e.ParentId.Equals(section.Id));
                foreach (var item in childCategories)
                {
                    section.ChildSection.Add(new SectionVewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Order = item.Order,
                        ParentSection = section
                    });
                }
                section.ChildSection = section.ChildSection.OrderBy(e => e.Order).ToList();
            }
            parentSections = parentSections.OrderBy(e => e.Order).ToList();
            return parentSections;
        }
    }
}
