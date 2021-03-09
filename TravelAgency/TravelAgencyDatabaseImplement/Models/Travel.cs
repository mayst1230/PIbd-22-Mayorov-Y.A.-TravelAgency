using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TravelAgencyDatabaseImplement.Models
{
    public class Travel
    {
        public int Id { get; set; }

        [Required]
        public string TravelName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual List<TravelCondition> TravelConditions { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
