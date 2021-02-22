using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyListImplement.Implements
{
    public class AgencyStorage : IAgencyStorage
    {
        private readonly DataListSingleton source;

        public AgencyStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<AgencyViewModel> GetFullList()
        {
            List<AgencyViewModel> result = new List<AgencyViewModel>();
            foreach (var agency in source.Agencies)
            {
                result.Add(CreateModel(agency));
            }
            return result;
        }

        public List<AgencyViewModel> GetFilteredList(AgencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<AgencyViewModel> result = new List<AgencyViewModel>();
            foreach (var agency in source.Agencies)
            {
                if (agency.AgencyName.Contains(model.AgencyName))
                {
                    result.Add(CreateModel(agency));
                }
            }
            return result;
        }

        public AgencyViewModel GetElement(AgencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var agency in source.Agencies)
            {
                if (agency.Id == model.Id || agency.AgencyName == model.AgencyName)
                {
                    return CreateModel(agency);
                }
            }
            return null;
        }

        public void Insert(AgencyBindingModel model)
        {
            Agency tempAgency = new Agency
            {
                Id = 1,
                AgencyTravels = new Dictionary<int, int>(),
                CreationDate = DateTime.Now
            };
            foreach (var agency in source.Agencies)
            {
                if (agency.Id >= tempAgency.Id)
                {
                    tempAgency.Id = agency.Id + 1;
                }
            }
            source.Agencies.Add(CreateModel(model, tempAgency));
        }

        public void Update(AgencyBindingModel model)
        {
            Agency tempAgency = null;
            foreach (var agency in source.Agencies)
            {
                if (agency.Id == model.Id)
                {
                    tempAgency = agency;
                }
            }
            if (tempAgency == null)
            {
                throw new Exception("Склад не найден");
            }
            CreateModel(model, tempAgency);
        }

        public void Delete(AgencyBindingModel model)
        {
            for (int i = 0; i < source.Agencies.Count; i++)
            {
                if (source.Agencies[i].Id == model.Id)
                {
                    source.Agencies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Склад не найден");
        }

        private Agency CreateModel(AgencyBindingModel model, Agency agency)
        {
            agency.AgencyName = model.AgencyName;
            agency.FullNameResponsible = model.FullNameResponsible;

            foreach (var key in agency.AgencyTravels.Keys.ToList())
            {
                if (!model.AgencyTravels.ContainsKey(key))
                {
                    agency.AgencyTravels.Remove(key);
                }
            }

            foreach (var travel in model.AgencyTravels)
            {
                if (agency.AgencyTravels.ContainsKey(travel.Key))
                {
                    agency.AgencyTravels[travel.Key] = model.AgencyTravels[travel.Key].Item2;
                }
                else
                {
                    agency.AgencyTravels.Add(travel.Key, model.AgencyTravels[travel.Key].Item2);
                }
            }
            return agency;
        }

        private AgencyViewModel CreateModel(Agency agency)
        {
            Dictionary<int, (string, int)> agencyTravels = new Dictionary<int, (string, int)>();
            foreach (var at in agency.AgencyTravels)
            {
                string travelName = string.Empty;
                foreach (var travel in source.Travels)
                {
                    if (at.Key == travel.Id)
                    {
                        travelName = travel.TravelName;
                        break;
                    }
                }
                agencyTravels.Add(at.Key, (travelName, at.Value));
            }

            return new AgencyViewModel
            {
                Id = agency.Id,
                AgencyName = agency.AgencyName,
                FullNameResponsible = agency.FullNameResponsible,
                CreationDate = agency.CreationDate,
                AgencyTravels = agencyTravels
            };
        }
    }
}
