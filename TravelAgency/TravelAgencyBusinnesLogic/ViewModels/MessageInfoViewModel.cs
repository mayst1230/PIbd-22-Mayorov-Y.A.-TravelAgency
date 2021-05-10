using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using TravelAgencyBusinnesLogic.Attributes;

namespace TravelAgencyBusinnesLogic.ViewModels
{
    public class MessageInfoViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        
        [DataMember]
        [Column(title: "Отправитель", width: 100)]
        public string SenderName { get; set; }
        
        [DataMember]
        [Column(title: "Дата письма", width: 50)]
        public DateTime DateDelivery { get; set; }

        [DataMember]
        [Column(title: "Заголовок", width: 150)]
        public string Subject { get; set; }

        [DataMember]
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Body { get; set; }
    }
}
