using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.BusinessLogics
{
    public class TravelLogic
    {
        private readonly ITravelStorage _travelStorage;
        public TravelLogic(ITravelStorage travelStorage)
        {
            _travelStorage = travelStorage;
        }
        public List<TravelViewModel> Read(TravelBindingModel model)
        {
            if (model == null)
            {
                return _travelStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TravelViewModel> { _travelStorage.GetElement(model) };
            }
            return _travelStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(TravelBindingModel model)
        {
            var element = _travelStorage.GetElement(new TravelBindingModel
            {
                TravelName = model.TravelName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть условие поездки с таким названием");
            }
            if (model.Id.HasValue)
            {
                _travelStorage.Update(model);
            }
            else
            {
                _travelStorage.Insert(model);
            }
        }
        public void Delete(TravelBindingModel model)
        {
            var element = _travelStorage.GetElement(new TravelBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Условие поездки не найдено");
            }
            _travelStorage.Delete(model);
        }
    }
}
