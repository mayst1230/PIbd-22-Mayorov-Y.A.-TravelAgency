using System.Collections.Generic;
using System.ComponentModel;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class SetViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название условия поездки")]
        public string SetName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SetTravels { get; set; }
    }
}
