using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebShop.Domain.Models.Cart;
using WebShop.Interfaces;

namespace WebShop.Services
{
    public class CookieCartStore : ICartStore
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cartName;

        public Cart Cart
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

        public CookieCartStore(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartName = "cart" + (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                _httpContextAccessor.HttpContext.User.Identity.Name : string.Empty);
        }
    }
}
