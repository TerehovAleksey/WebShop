using System.Collections.Generic;
using System.Linq;
using WebShop.Models.Products;

namespace WebShop.Models.Cart
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }
        public int ItemsCount => Items?.Sum(x => x.Value) ?? 0;
    }
}
