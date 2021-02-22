﻿using TravelAgencyBusinnesLogic.Enums;
using System;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int SetId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
