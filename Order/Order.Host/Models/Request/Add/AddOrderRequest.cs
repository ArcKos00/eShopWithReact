﻿using Order.Host.Models.Dto;

namespace Order.Host.Models.Request.Add
{
    public class AddOrderRequest : UserIdRequest
    {
        public List<OrderItem> BasketList { get; set; } = new List<OrderItem>();
    }
}
