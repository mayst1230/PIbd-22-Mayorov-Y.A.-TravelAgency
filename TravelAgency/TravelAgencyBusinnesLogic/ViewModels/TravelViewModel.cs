using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    [DataContract]
    public class TravelViewModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        [DisplayName("Название поездки")]
        public string TravelName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}
