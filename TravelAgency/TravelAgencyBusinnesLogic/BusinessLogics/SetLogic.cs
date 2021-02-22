﻿using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.BusinessLogics
{
    public class SetLogic
    {
        private readonly ISetStorage _setStorage;
        public SetLogic(ISetStorage setStorage)
        {
            _setStorage = setStorage;
        }
        public List<SetViewModel> Read(SetBindingModel model)
        {
            if (model == null)
            {
                return _setStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SetViewModel> { _setStorage.GetElement(model) };
            }
            return _setStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(SetBindingModel model)
        {
            var element = _setStorage.GetElement(new SetBindingModel
            {
                SetName = model.SetName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть условие поездки с таким названием");
            }
            if (model.Id.HasValue)
            {
                _setStorage.Update(model);
            }
            else
            {
                _setStorage.Insert(model);
            }
        }
        public void Delete(SetBindingModel model)
        {
            var element = _setStorage.GetElement(new SetBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Условие поездки не найдено");
            }
            _setStorage.Delete(model);
        }
    }
}