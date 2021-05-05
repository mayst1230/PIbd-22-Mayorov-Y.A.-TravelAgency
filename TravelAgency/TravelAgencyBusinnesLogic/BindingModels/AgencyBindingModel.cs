using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    [DataContract]
    public class AgencyBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string AgencyName { get; set; }

        [DataMember]
        public string FullNameResponsible { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> AgencyTravels { get; set; }
    }
}
