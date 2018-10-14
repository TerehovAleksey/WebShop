using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using WebShop.Clients.Base;
using WebShop.Domain.Dto.Order;
using WebShop.Interfaces;

namespace WebShop.Clients.Services.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        protected sealed override string ServiceAddress { get; set; }

        public OrdersClient(IConfiguration configuration) : base(configuration)
        {
            ServiceAddress = "api/orders";
        }

        public OrderDto CreateOrder(CreateOrderModel orderModel, string userName)
        {
            var url = $"{ServiceAddress}/{userName}";
            var response = Post(url, orderModel);
            var result = response.Content.ReadAsAsync<OrderDto>().Result;
            return result;

        }

        public OrderDto GetOrderById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<OrderDto>(url);
            return result;
        }

        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
            var url = $"{ServiceAddress}/user/{userName}";
            var result = Get<List<OrderDto>>(url);
            return result;
        }
    }
}
