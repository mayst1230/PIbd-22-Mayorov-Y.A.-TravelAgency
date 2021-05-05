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
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string AgencyFileName = "Agency.xml";
        public List<Condition> Conditions { get; set; }
        public List<Order> Orders { get; set; }
        public List<Client> Clients { get; set; }
        public List<Travel> Travels { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<Agency> Agencies { get; set; }
        private FileDataListSingleton()
        {
            Conditions = LoadConditions();
            Orders = LoadOrders();
            Travels = LoadTravels();
            Clients = LoadClients();
            Agencies = LoadAgencies();
            Implementers = LoadImplementers();
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
            SaveAgencies();
            SaveImplementers();
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
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = Convert.ToInt32(elem.Element("ClientId").Value),
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

        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Attribute("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Attribute("PauseTime").Value),
                    });
                }
            }
            return list;
        }

        private List<Agency> LoadAgencies()
        {
            var list = new List<Agency>();

            if (File.Exists(AgencyFileName))
            {
                XDocument xDocument = XDocument.Load(AgencyFileName);

                var xElements = xDocument.Root.Elements("Agency").ToList();

                foreach (var agency in xElements)
                {
                    var agencyTravels = new Dictionary<int, int>();

                    foreach (var travel in agency.Element("AgencyTravels").Elements("AgencyTravel").ToList())
                    {
                        agencyTravels.Add(Convert.ToInt32(travel.Element("Key").Value), Convert.ToInt32(travel.Element("Value").Value));
                    }

                    list.Add(new Agency
                    {
                        Id = Convert.ToInt32(agency.Attribute("Id").Value),
                        AgencyName = agency.Element("AgencyName").Value,
                        FullNameResponsible = agency.Element("FullNameResponsible").Value,
                        CreationDate = Convert.ToDateTime(agency.Element("CreationDate").Value),
                        AgencyTravels = agencyTravels
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
                    new XElement("ClientId", order.ClientId),
                    new XElement("ImplementerId", order.ImplementerId),
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

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }

        private void SaveAgencies()
        {
            if (Agencies != null)
            {
                var xElement = new XElement("Agencies");

                foreach (var agency in Agencies)
                {
                    var travelElement = new XElement("AgencyTravels");

                    foreach (var condition in agency.AgencyTravels)
                    {
                        travelElement.Add(new XElement("AgencyTravel",
                            new XElement("Key", condition.Key),
                            new XElement("Value", condition.Value)));
                    }

                    xElement.Add(new XElement("Agency",
                        new XAttribute("Id", agency.Id),
                        new XElement("AgencyName", agency.AgencyName),
                        new XElement("FullNameResponsible", agency.FullNameResponsible),
                        new XElement("CreationDate", agency.CreationDate.ToString()),
                        travelElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(AgencyFileName);
            }
        }
    }
}
