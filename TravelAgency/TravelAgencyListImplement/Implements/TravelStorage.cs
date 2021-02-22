using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyListImplement.Models;
using System;
using System.Collections.Generic;

namespace TravelAgencyListImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
        private readonly DataListSingleton source;
        public TravelStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<TravelViewModel> GetFullList()
        {
            List<TravelViewModel> result = new List<TravelViewModel>();
            foreach (var component in source.Travels)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<TravelViewModel> result = new List<TravelViewModel>();
            foreach (var component in source.Travels)
            {
                if (component.TravelName.Contains(model.TravelName))
                {
                    result.Add(CreateModel(component));
                }
            }
            return result;
        }
        public TravelViewModel GetElement(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var component in source.Travels)
            {
                if (component.Id == model.Id || component.TravelName ==
               model.TravelName)
                {
                    return CreateModel(component);
                }
            }
            return null;
        }
        public void Insert(TravelBindingModel model)
        {
            Travel tempComponent = new Travel { Id = 1 };
            foreach (var component in source.Travels)
            {
                if (component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
            }
            source.Travels.Add(CreateModel(model, tempComponent));
        }
        public void Update(TravelBindingModel model)
        {
            Travel tempComponent = null;
            foreach (var component in source.Travels)
            {
                if (component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (tempComponent == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempComponent);
        }
        public void Delete(TravelBindingModel model)
        {
            for (int i = 0; i < source.Travels.Count; ++i)
            {
                if (source.Travels[i].Id == model.Id.Value)
                {
                    source.Travels.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Travel CreateModel(TravelBindingModel model, Travel component)
        {
            component.TravelName = model.TravelName;
            return component;
        }
        private TravelViewModel CreateModel(Travel component)
        {
            return new TravelViewModel
            {
                Id = component.Id,
                TravelName = component.TravelName
            };
        }
    }
}
