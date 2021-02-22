using TravelAgencyListImplement.Models;
using System.Collections.Generic;

namespace TravelAgencyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Travel> Travels { get; set; }
        public List<Order> Orders { get; set; }
        public List<Set> Sets { get; set; }

        private DataListSingleton()
        {
            Travels = new List<Travel>();
            Orders = new List<Order>();
            Sets = new List<Set>();
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
