using System.ComponentModel;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class TravelViewModel
    {
        public int Id { get; set; }

        [DisplayName("Условие поездки")]
        public string TravelName { get; set; }
    }
}
