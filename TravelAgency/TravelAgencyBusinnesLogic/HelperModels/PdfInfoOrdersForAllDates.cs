using System;
using System.Collections.Generic;
using System.Text;
using TravelAgencyBusinnesLogic.ViewModels;

namespace TravelAgencyBusinnesLogic.HelperModels
{
    public class PdfInfoOrdersForAllDates
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrdersForAllDatesViewModel> Orders { get; set; }
    }
}
