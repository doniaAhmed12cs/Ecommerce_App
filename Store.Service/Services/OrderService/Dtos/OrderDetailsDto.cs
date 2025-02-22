﻿using Store.Data.Entities.OrderEntity;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderService.Dtos
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset orderDate { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public string DeliveryMethodName { get; set; }
        public OrderStauts OrderStauts { get; set; }
        public OrderPaymentStatus OrderPaymentStatus { get; set; }
        public IReadOnlyList<OrderItem> Items { get; set; }
        public decimal ShippingPrice { get; set; }
        public string? BasketId { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Total { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}

