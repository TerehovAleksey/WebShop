using System.Linq;
using WebShop.Domain.Filters;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Products;
using WebShop.Interfaces;

namespace WebShop.Services
{
    public class CartService : ICartService
    {
        private readonly IProductData _productData;
        private readonly ICartStore _cartStore;

        public CartService(IProductData productData, ICartStore cartStore)
        {
            _productData = productData;
            _cartStore = cartStore;
        }

        public void AddToCart(int id)
        {
            var cart = _cartStore.Cart;
            var items = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (items != null)
            {
                items.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            }
            _cartStore.Cart = cart;
        }

        public void DecrementFromCart(int id)
        {
            var cart = _cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 0)
                {
                    item.Quantity--;
                }

                if (item.Quantity == 0)
                {
                    cart.Items.Remove(item);
                }
            }
            _cartStore.Cart = cart;
        }

        public void RemoveAll()
        {
            _cartStore.Cart.Items.Clear();
        }

        public void RemoveFromCart(int id)
        {
            var cart = _cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            _cartStore.Cart = cart;
        }

        public CartViewModel TransformCart()
        {
            var products = _productData.GetProducts(new ProiductFilter()
            {
                Ids = _cartStore.Cart.Items.Select(x => x.ProductId).ToList()
            }).Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();

            var r = new CartViewModel
            {
                Items = _cartStore.Cart.Items.ToDictionary(x => products.First(y => y.Id == x.ProductId), x => x.Quantity)
            };
            return r;
        }

    }
}
