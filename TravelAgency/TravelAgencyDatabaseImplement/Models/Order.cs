using System;
using TravelAgencyBusinnesLogic.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TravelId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public Travel Travel { get; set; }
    }
}
