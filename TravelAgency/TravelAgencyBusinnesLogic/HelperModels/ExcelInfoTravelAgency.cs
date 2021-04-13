using System;
using System.Collections.Generic;
using System.Text;
using TravelAgencyBusinnesLogic.ViewModels;

namespace TravelAgencyBusinnesLogic.HelperModels
{
    public class ExcelInfoTravelAgency
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportTravelAgencyConditionViewModel> TravelAgencyConditions { get; set; }
    }
}
