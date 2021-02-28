using System.Collections.Generic;
using System.ComponentModel;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class TravelViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название поездки")]
        public string TravelName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}
