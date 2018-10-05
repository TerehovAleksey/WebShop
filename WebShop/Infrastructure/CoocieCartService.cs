using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Domain.Filters;
using WebShop.Interfaces;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Products;

namespace WebShop.Infrastructure
{
    public class CoocieCartService : ICartService
    {
        private readonly IProductData _productData;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cartName;

        public CoocieCartService(IProductData productData, IHttpContextAccessor httpContextAccessor)
        {
            _productData = productData;
            _httpContextAccessor = httpContextAccessor;
            _cartName = "cart" + (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                _httpContextAccessor.HttpContext.User.Identity.Name : string.Empty);
        }

        private Cart Cart
        {
            get
            {
                var coocie = _httpContextAccessor.HttpContext.Request.Cookies[_cartName];
                string json = string.Empty;
                Cart cart = null;
                if (coocie == null)
                {
                    cart = new Cart { Items = new List<CartItem>() };
                    json = JsonConvert.SerializeObject(cart);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName, json, new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
                    return cart;
                }
                json = coocie;
                cart = JsonConvert.DeserializeObject<Cart>(json);
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_cartName);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName, json, new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
                return cart;
            }
            set
            {
                var json = JsonConvert.SerializeObject(value);
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_cartName);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(_cartName, json, new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            }
        }

        public void AddToCard(int id)
        {
            var cart = Cart;
            var items = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (items != null)
            {
                items.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            }
            Cart = cart;
        }

        public void DecrementFromCard(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 0)
                    item.Quantity--;
                if (item.Quantity == 0)
                    cart.Items.Remove(item);
            }
            Cart = cart;
        }

        public void RemoveAll()
        {
            Cart = new Cart { Items = new List<CartItem>() };
        }

        public void RemoveFromCard(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item!=null)
            {
                cart.Items.Remove(item);
            }
            Cart = cart;
        }

        public CartViewModel TransformCart()
        {
            var products = _productData.GetProducts(new ProiductFilter()
            {
                Ids = Cart.Items.Select(x => x.ProductId).ToList()
            }).Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand!=null?p.Brand.Name:string.Empty
            }).ToList();

            var r = new CartViewModel
            {
                Items = Cart.Items.ToDictionary(x => products.First(y => y.Id == x.ProductId), x => x.Quantity)
            };
            return r;
        }

    }
}
