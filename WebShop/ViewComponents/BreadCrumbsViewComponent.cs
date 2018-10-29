using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WebShop.Domain.Models.BreadCrumbs;
using WebShop.Interfaces;

namespace WebShop.ViewComponents
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public BreadCrumbsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<IViewComponentResult> InvokeAsync(BreadCrumbType type, int id, BreadCrumbType fromType)
        {
            if (!Enum.IsDefined(typeof(BreadCrumbType), type))
            {
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(BreadCrumbType));
            }

            if (!Enum.IsDefined(typeof(BreadCrumbType), fromType))
            {
                throw new InvalidEnumArgumentException(nameof(fromType), (int)fromType, typeof(BreadCrumbType));
            }

            switch (type)
            {
                case BreadCrumbType.Section:
                    var section = _productData.GetSectionById(id);
                    return View(new List<BreadCrumbViewModel>()
                    {
                        new BreadCrumbViewModel()
                        {
                            BreadCrumbType = type,
                            Id = id,
                            Name = section.Name
                        }
                    });
                case BreadCrumbType.Brand:
                    var brand = _productData.GetBrandById(id);
                    return View(new List<BreadCrumbViewModel>()
                    {
                        new BreadCrumbViewModel()
                        {
                            BreadCrumbType = type,
                            Id = id,
                            Name = brand.Name
                        }
                    });
                case BreadCrumbType.Item:
                    var crumbs = GetItemBreadCrumbs(id, fromType, type);
                    return View(crumbs);
                case BreadCrumbType.None:
                default:
                    return View(new List<BreadCrumbViewModel>());
            }
        }

        private IEnumerable<BreadCrumbViewModel> GetItemBreadCrumbs(int id, BreadCrumbType fromType, BreadCrumbType type)
        {
            var item = _productData.GetProductById(id);
            var crumbs = new List<BreadCrumbViewModel>();

            if (fromType == BreadCrumbType.Section)
            {
                crumbs.Add(new BreadCrumbViewModel()
                {
                    BreadCrumbType = fromType,
                    Id = item.Section.Id,
                    Name = item.Section.Name
                });
            }
            else
            {
                crumbs.Add(new BreadCrumbViewModel()
                {
                    BreadCrumbType = fromType,
                    Id = item.Brand.Id,
                    Name = item.Brand.Name
                });
            }

            crumbs.Add(new BreadCrumbViewModel()
            {
                BreadCrumbType = type,
                Id = item.Id,
                Name = item.Name
            });
            return crumbs;
        }
    }
}
