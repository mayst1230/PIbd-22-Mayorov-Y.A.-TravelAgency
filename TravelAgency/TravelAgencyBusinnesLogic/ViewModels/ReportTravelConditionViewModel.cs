using System;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class ReportTravelConditionViewModel
    {
        public string TravelName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Conditions { get; set; }
    }
}
