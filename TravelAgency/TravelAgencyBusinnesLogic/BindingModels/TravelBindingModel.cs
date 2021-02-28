using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    public class TravelBindingModel
    {
        public int? Id { get; set; }
        public string TravelName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}