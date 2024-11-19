﻿using Store.Data.Entities;
using Store.Service.Services.OrderService.Dtos;

namespace Store.Service.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderDetailsDto> CreateOrderAsync(OrderDto input);
        Task<IReadOnlyList<OrderDetailsDto>> GetAllOrdersForUsersAsync(string buyerEmail);
        Task<OrderDetailsDto> GetOrderByIdAsync(Guid id,string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodsAsync();
    }
}