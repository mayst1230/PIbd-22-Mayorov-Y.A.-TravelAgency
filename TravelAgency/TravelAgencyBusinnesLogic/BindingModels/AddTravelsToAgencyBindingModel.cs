using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    public class AddTravelsToAgencyBindingModel
    {
        public int AgencyId { get; set; }

        public int TravelId { get; set; }

        public int Count { get; set; }
    }
}
