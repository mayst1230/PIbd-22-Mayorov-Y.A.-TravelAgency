﻿using System.Runtime.Serialization;

namespace TravelAgencyBusinnesLogic.BindingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int TravelId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}