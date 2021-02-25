using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class AgencyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string AgencyName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string FullNameResponsible { get; set; }

        [DisplayName("Дата создания")]
        public DateTime CreationDate { get; set; }

        public Dictionary<int, (string, int)> AgencyConditions { get; set; }
    }
}
