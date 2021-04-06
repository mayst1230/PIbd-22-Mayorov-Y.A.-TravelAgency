using System;
using System.Collections.Generic;
using System.Text;
using TravelAgencyBusinnesLogic.ViewModels;

namespace TravelAgencyBusinnesLogic.HelperModels
{
    public class WordInfoTravelAgency
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<AgencyViewModel> Agencies { get; set; }
    }
}
