using TravelAgencyBusinnesLogic.ViewModels;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportTravelConditionViewModel> TravelConditions { get; set; }
    }
}
