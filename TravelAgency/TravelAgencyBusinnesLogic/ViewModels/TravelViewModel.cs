using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using TravelAgencyBusinnesLogic.Attributes;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    [DataContract]
    public class TravelViewModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        [Column(title: "Путевка", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TravelName { get; set; }

        [DataMember]
        [Column(title: "Цена", width: 50)]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> TravelConditions { get; set; }
    }
}
