using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgencyListImplement.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string FullNameResponsible { get; set; }
        public DateTime CreationDate { get; set; }
        public Dictionary<int, int> AgencyTravels { get; set; }
    }
}
