using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.BusinessLogics
{
    public class ConditionLogic
    {
        private readonly IConditionStorage _conditionStorage;
        public ConditionLogic(IConditionStorage conditionStorage)
        {
            _conditionStorage = conditionStorage;
        }
        public List<ConditionViewModel> Read(ConditionBindingModel model)
        {
            if (model == null)
            {
                return _conditionStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ConditionViewModel> { _conditionStorage.GetElement(model) };
            }
            return _conditionStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ConditionBindingModel model)
        {
            var element = _conditionStorage.GetElement(new ConditionBindingModel
            {
                ConditionName = model.ConditionName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть условие поездки с таким названием");
            }
            if (model.Id.HasValue)
            {
                _conditionStorage.Update(model);
            }
            else
            {
                _conditionStorage.Insert(model);
            }
        }
        public void Delete(ConditionBindingModel model)
        {
            var element = _conditionStorage.GetElement(new ConditionBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Условие поездки не найдено");
            }
            _conditionStorage.Delete(model);
        }
    }
}