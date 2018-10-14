﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.Dto.Order;
using WebShop.Domain.Models.Cart;
using WebShop.Domain.Models.Order;
using WebShop.Interfaces;

namespace WebShop.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    [ApiController]
    public class OrderApiController : ControllerBase, IOrderService
    {
        private readonly IOrderService _orderService;

        public OrderApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{userName?}")]
        public OrderDto CreateOrder([FromBody]CreateOrderModel orderModel, string userName)
        {
            return _orderService.CreateOrder(orderModel, userName);
        }

        [HttpGet("{id}")]
        public OrderDto GetOrderById(int id)
        {
            return _orderService.GetOrderById(id);
        }

        [HttpGet("user/{userName}")]
        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
            return _orderService.GetUserOrders(userName);
        }
    }
}