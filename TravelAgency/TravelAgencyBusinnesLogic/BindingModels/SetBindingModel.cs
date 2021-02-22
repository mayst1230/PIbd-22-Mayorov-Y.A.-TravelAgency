using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    public class SetBindingModel
    {
        public int? Id { get; set; }
        public string SetName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SetTravels { get; set; }
    }
}
