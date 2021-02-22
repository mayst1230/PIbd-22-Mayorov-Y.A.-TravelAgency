using System;
using System.Collections.Generic;
using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyBusinnesLogic.Interfaces;

namespace TravelAgencyBusinnesLogic.BusinessLogics
{
    public class AgencyLogic
    {
        private readonly IAgencyStorage _agencyStorage;
        private readonly ITravelStorage _travelStorage;
        public AgencyLogic(IAgencyStorage agencyStorage, ITravelStorage travelStorage)
        {
            _agencyStorage = agencyStorage;
            _travelStorage = travelStorage;
        }

        public List<AgencyViewModel> Read(AgencyBindingModel model)
        {
            if (model == null)
            {
                return _agencyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<AgencyViewModel> { _agencyStorage.GetElement(model) };
            }
            return _agencyStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(AgencyBindingModel model)
        {
            var agency = _agencyStorage.GetElement(new AgencyBindingModel
            {
                AgencyName = model.AgencyName
            });
            if (agency != null && agency.Id != model.Id)
            {
                throw new Exception("Уже есть такой склад");
            }
            if (model.Id.HasValue)
            {
                _agencyStorage.Update(model);
            }
            else
            {
                _agencyStorage.Insert(model);
            }
        }

        public void Delete(AgencyBindingModel model)
        {
            var agency = _agencyStorage.GetElement(new AgencyBindingModel
            {
                Id = model.Id
            });
            if (agency == null)
            {
                throw new Exception("Склад не найден");
            }
            _agencyStorage.Delete(model);
        }

        public void AddTravels(AddTravelsToAgencyBindingModel model)
        {
            var agency = _agencyStorage.GetElement(new AgencyBindingModel
            {
                Id = model.AgencyId
            });
            if (agency == null)
            {
                throw new Exception("Склад не найден");
            }

            var travel = _travelStorage.GetElement(new TravelBindingModel
            {
                Id = model.TravelId
            });
            if (travel == null)
            {
                throw new Exception("Условие поездки не найдено");
            }

            var agencyTravels = agency.AgencyTravels;
            if (agencyTravels.ContainsKey(travel.Id))
            {
                agencyTravels[travel.Id] = (agencyTravels[travel.Id].Item1, agencyTravels[travel.Id].Item2 + model.Count);
            }
            else
            {
                agencyTravels.Add(travel.Id, (travel.TravelName, model.Count));
            }
            _agencyStorage.Update(new AgencyBindingModel
            {
                Id = agency.Id,
                AgencyName = agency.AgencyName,
                FullNameResponsible = agency.FullNameResponsible,
                CreationDate = agency.CreationDate,
                AgencyTravels = agencyTravels
            });
        }
    }
}
