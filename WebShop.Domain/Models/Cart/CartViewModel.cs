using System.Collections.Generic;
using System.Linq;
using WebShop.Domain.Models.Products;

namespace WebShop.Domain.Models.Cart
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }
        public int ItemsCount => Items?.Sum(x => x.Value) ?? 0;
    }
}
