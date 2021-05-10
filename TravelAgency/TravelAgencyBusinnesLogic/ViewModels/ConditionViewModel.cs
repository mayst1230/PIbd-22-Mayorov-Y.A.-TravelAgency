using System.ComponentModel;
using TravelAgencyBusinnesLogic.Attributes;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class ConditionViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название условия поездки", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ConditionName { get; set; }
    }
}
