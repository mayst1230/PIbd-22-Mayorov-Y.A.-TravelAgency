using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    public class AgencyBindingModel
    {
        public int? Id { get; set; }

        public string AgencyName { get; set; }

        public string FullNameResponsible { get; set; }

        public DateTime CreationDate { get; set; }

        public Dictionary<int, (string, int)> AgencyTravels { get; set; }
    }
}
