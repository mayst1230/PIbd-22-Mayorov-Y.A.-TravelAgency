using System;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class ReportTravelAgencyConditionViewModel
    {
        public string TravelAgencyName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Conditions { get; set; }
    }
}
