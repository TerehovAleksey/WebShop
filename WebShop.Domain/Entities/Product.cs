using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        //секция к которой принадлежит товар
        public int SectionId { get; set; }

        //бренд товара
        public int? BrandId { get; set; }

        //ссылка на картинку
        public string ImageUrl { get; set; }

        //цена
        public decimal Price { get; set; }
    }
}
