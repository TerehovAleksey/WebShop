using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interfaces;
using WebShop.Domain.Models.Products;

namespace WebShop.ViewComponents
{
    public class SectionViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public SectionViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<IViewComponentResult> InvokeAsync(string sectionId)
        {
            int.TryParse(sectionId, out var sectionIdInt);
            var sections = GetSections(sectionIdInt, out var parentSectionId);
            return View(new SectionCompleteViewModel()
            {
                Sections = sections,
                CurrentSectionId = sectionIdInt,
                CurrentParrentSectionId = parentSectionId
            });
        }

        private List<SectionVewModel> GetSections(int? sectionId, out int? parentSectionId)
        {
            parentSectionId = null;
            var allSections = _productData.GetSections();
            var parentCategories = allSections.Where(e => !e.ParentId.HasValue).ToArray();
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
                var childCategories = allSections.Where(e => e.ParentId.Equals(section.Id));
                foreach (var item in childCategories)
                {
                    if (item.Id == sectionId)
                    {
                        parentSectionId = section.Id;
                    }

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
