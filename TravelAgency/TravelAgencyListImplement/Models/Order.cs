using TravelAgencyBusinnesLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgencyListImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TravelId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
