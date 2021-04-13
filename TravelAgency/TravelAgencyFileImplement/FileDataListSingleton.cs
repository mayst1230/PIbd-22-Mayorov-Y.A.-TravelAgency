using TravelAgencyBusinnesLogic.Enums;
using TravelAgencyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TravelAgencyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ConditionFileName = "Condition.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string TravelFileName = "Travel.xml";
        private readonly string ClientFileName = "Client.xml";
        public List<Condition> Conditions { get; set; }
        public List<Order> Orders { get; set; }
        public List<Travel> Travels { get; set; }
        public List<Client> Clients { get; set; }
        private FileDataListSingleton()
        {
            Conditions = LoadConditions();
            Orders = LoadOrders();
            Travels = LoadTravels();
            Clients = LoadClients();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveConditions();
            SaveOrders();
            SaveTravels();
            SaveClients();
        }

        private List<Condition> LoadConditions()
        {
            var list = new List<Condition>();
            if (File.Exists(ConditionFileName))
            {
                XDocument xDocument = XDocument.Load(ConditionFileName);
                var xElements = xDocument.Root.Elements("Condition").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Condition
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ConditionName = elem.Element("ConditionName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TravelId = Convert.ToInt32(elem.Element("TravelId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Travel> LoadTravels()
        {
            var list = new List<Travel>();
            if (File.Exists(TravelFileName))
            {
                XDocument xDocument = XDocument.Load(TravelFileName);
                var xElements = xDocument.Root.Elements("Travel").ToList();
                foreach (var elem in xElements)
                {
                    var travCond = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("TravelConditions").Elements("TravelCondition").ToList())
                    {
                        travCond.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Travel
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TravelName = elem.Element("TravelName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        TravelConditions = travCond
                    });
                }
            }
            return list;
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }
            return list;
        }

        private void SaveConditions()
        {
            if (Conditions != null)
            {
                var xElement = new XElement("Conditions");
                foreach (var condition in Conditions)
                {
                    xElement.Add(new XElement("Condition",
                    new XAttribute("Id", condition.Id),
                    new XElement("ConditionName", condition.ConditionName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ConditionFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("TravelId", order.TravelId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveTravels()
        {
            if (Travels != null)
            {
                var xElement = new XElement("Travels");
                foreach (var travel in Travels)
                {
                    var compElement = new XElement("TravelConditions");
                    foreach (var condition in travel.TravelConditions)
                    {
                        compElement.Add(new XElement("TravelCondition",
                        new XElement("Key", condition.Key),
                        new XElement("Value", condition.Value)));
                    }
                    xElement.Add(new XElement("Travel",
                     new XAttribute("Id", travel.Id),
                     new XElement("TravelName", travel.TravelName),
                     new XElement("Price", travel.Price),
                     compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(TravelFileName);
            }
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
    }
}
