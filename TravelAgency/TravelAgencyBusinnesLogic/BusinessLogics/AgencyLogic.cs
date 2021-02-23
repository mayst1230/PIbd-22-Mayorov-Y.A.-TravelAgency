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
        private readonly IConditionStorage _conditionStorage;
        public AgencyLogic(IAgencyStorage agencyStorage, IConditionStorage conditionStorage)
        {
            _agencyStorage = agencyStorage;
            _conditionStorage = conditionStorage;
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

        public void AddConditions(AddConditionsToAgencyBindingModel model)
        {
            var agency = _agencyStorage.GetElement(new AgencyBindingModel
            {
                Id = model.AgencyId
            });
            if (agency == null)
            {
                throw new Exception("Склад не найден");
            }

            var condition = _conditionStorage.GetElement(new ConditionBindingModel
            {
                Id = model.ConditionId
            });
            if (condition == null)
            {
                throw new Exception("Условие поездки не найдено");
            }

            var agencyTravels = agency.AgencyConditions;
            if (agencyTravels.ContainsKey(condition.Id))
            {
                agencyTravels[condition.Id] = (agencyTravels[condition.Id].Item1, agencyTravels[condition.Id].Item2 + model.Count);
            }
            else
            {
                agencyTravels.Add(condition.Id, (condition.ConditionName, model.Count));
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
