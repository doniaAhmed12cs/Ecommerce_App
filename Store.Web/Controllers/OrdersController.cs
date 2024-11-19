﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities;
using Store.Service.HandelResponse;
using Store.Service.Services.OrderService;
using Store.Service.Services.OrderService.Dtos;
using System.Security.Claims;

namespace Store.Web.Controllers
{
  
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]

        public async Task<ActionResult<OrderDetailsDto>> CreatOrderAsync(OrderDto input)
        {
            var order = await _orderService.CreateOrderAsync(input);
            if (order == null)
            {

                return BadRequest(new Response(400, "Erorr  While Creating Your Order"));
            }
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDetailsDto>>> GetAllOrdersForUsersAsync()
        {
            var email=User.FindFirstValue(ClaimTypes.Email);
            var order=await _orderService.GetAllOrdersForUsersAsync(email);   
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderByIdAsync(Guid id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var order = await _orderService.GetOrderByIdAsync(id, email);
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetAllDeliveryMethodsAsync()
            =>Ok(await _orderService.GetAllDeliveryMethodsAsync());

    }
}
