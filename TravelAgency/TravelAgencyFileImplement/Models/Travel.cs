using System.Collections.Generic;

namespace TravelAgencyFileImplement.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string TravelName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> TravelConditions { get; set; }
    }
}
