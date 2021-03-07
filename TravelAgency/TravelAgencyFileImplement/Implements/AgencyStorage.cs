using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyFileImplement.Models;

namespace TravelAgencyFileImplement.Implements
{
    public class AgencyStorage : IAgencyStorage
    {
        private readonly FileDataListSingleton source;

        public AgencyStorage() 
        {
            source = FileDataListSingleton.GetInstance();
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
                    agency.AgencyTravels[travel.Key] =
                        model.AgencyTravels[travel.Key].Item2;
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
            Dictionary<int, (string, int)> agencyConditions = new Dictionary<int, (string, int)>();

            foreach (var agencyTravel in agency.AgencyTravels)
            {
                string conditionName = string.Empty;
                foreach (var condition in source.Conditions)
                {
                    if (agencyTravel.Key == condition.Id)
                    {
                        conditionName = condition.ConditionName;
                        break;
                    }
                }
                agencyConditions.Add(agencyTravel.Key, (conditionName, agencyTravel.Value));
            }

            return new AgencyViewModel
            {
                Id = agency.Id,
                AgencyName = agency.AgencyName,
                FullNameResponsible = agency.FullNameResponsible,
                CreationDate = agency.CreationDate,
                AgencyConditions = agencyConditions
            };
        }

        public List<AgencyViewModel> GetFullList()
        {
            return source.Agencies.Select(CreateModel).ToList();
        }

        public List<AgencyViewModel> GetFilteredList(AgencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Agencies.Where(xAgency => xAgency.AgencyName.Contains(model.AgencyName)).Select(CreateModel).ToList();
        }

        public AgencyViewModel GetElement(AgencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var agency = source.Agencies.FirstOrDefault(xAgency => xAgency.AgencyName == model.AgencyName || xAgency.Id == model.Id);

            return agency != null ? CreateModel(agency) : null;
        }

        public void Insert(AgencyBindingModel model)
        {
            int maxId = source.Agencies.Count > 0 ? source.Agencies.Max(xAgency => xAgency.Id) : 0;
            var agency = new Agency { Id = maxId + 1, AgencyTravels = new Dictionary<int, int>(), CreationDate = DateTime.Now };
            source.Agencies.Add(CreateModel(model, agency));
        }

        public void Update(AgencyBindingModel model)
        {
            var agency = source.Agencies.FirstOrDefault(xAgency => xAgency.Id == model.Id);

            if (agency == null)
            {
                throw new Exception("Склад не найден");
            }

            CreateModel(model, agency);
        }

        public void Delete(AgencyBindingModel model)
        {
            var agency = source.Agencies.FirstOrDefault(xAgency => xAgency.Id == model.Id);

            if (agency != null)
            {
                source.Agencies.Remove(agency);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
        }

        public bool TakeFromTravelAgency(Dictionary<int, (string, int)> conditions, int travelCount)
        {
            foreach (var condition in conditions)
            {
                int count = source.Agencies.Where(material => material.AgencyTravels.ContainsKey(condition.Key)).Sum(material => material.AgencyTravels[condition.Key]);

                if (count < condition.Value.Item2 * travelCount)
                {
                    return false;
                }
            }

            foreach (var condition in conditions)
            {
                int count = condition.Value.Item2 * travelCount;
                IEnumerable<Agency> agency = source.Agencies.Where(material => material.AgencyTravels.ContainsKey(condition.Key));

                foreach (Agency agencies in agency)
                {
                    if (agencies.AgencyTravels[condition.Key] <= count)
                    {
                        count -= agencies.AgencyTravels[condition.Key];
                        agencies.AgencyTravels.Remove(condition.Key);
                    }
                    else
                    {
                        agencies.AgencyTravels[condition.Key] -= count;
                        count = 0;
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            return true;
        }
    }
}
