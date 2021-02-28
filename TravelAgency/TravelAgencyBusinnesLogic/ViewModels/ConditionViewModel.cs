using System.ComponentModel;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class ConditionViewModel
    {
        public int Id { get; set; }

        [DisplayName("Условие поездки")]
        public string ConditionName { get; set; }
    }
}
