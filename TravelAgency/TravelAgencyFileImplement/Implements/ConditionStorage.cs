using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyFileImplement.Implements
{
    public class ConditionStorage : IConditionStorage
    {
        private readonly FileDataListSingleton source;

        public ConditionStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<ConditionViewModel> GetFullList()
        {
            return source.Conditions
            .Select(CreateModel)
           .ToList();
        }
        public List<ConditionViewModel> GetFilteredList(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Conditions
            .Where(rec => rec.ConditionName.Contains(model.ConditionName))
           .Select(CreateModel)
            .ToList();
        }
        public ConditionViewModel GetElement(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var condition = source.Conditions
            .FirstOrDefault(rec => rec.ConditionName == model.ConditionName ||
           rec.Id == model.Id);
            return condition != null ? CreateModel(condition) : null;
        }
        public void Insert(ConditionBindingModel model)
        {
            int maxId = source.Conditions.Count > 0 ? source.Conditions.Max(rec =>
           rec.Id) : 0;
            var element = new Condition { Id = maxId + 1 };
            source.Conditions.Add(CreateModel(model, element));
        }
        public void Update(ConditionBindingModel model)
        {
            var element = source.Conditions.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(ConditionBindingModel model)
        {
            Condition element = source.Conditions.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Conditions.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Condition CreateModel(ConditionBindingModel model, Condition component)
        {
            component.ConditionName = model.ConditionName;
            return component;
        }
        private ConditionViewModel CreateModel(Condition condition)
        {
            return new ConditionViewModel
            {
                Id = condition.Id,
                ConditionName = condition.ConditionName
            };
        }
    }
}