using TravelAgencyListImplement.Models;
using System.Collections.Generic;

namespace TravelAgencyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Condition> Conditions { get; set; }
        public List<Order> Orders { get; set; }
        public List<Travel> Travels { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }

        private DataListSingleton()
        {
            Conditions = new List<Condition>();
            Orders = new List<Order>();
            Travels = new List<Travel>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
