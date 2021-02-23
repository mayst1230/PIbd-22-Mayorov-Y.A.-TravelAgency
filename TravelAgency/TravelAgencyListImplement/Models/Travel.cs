using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgencyListImplement.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string TravelName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> TravelConditions { get; set; }
    }
}
