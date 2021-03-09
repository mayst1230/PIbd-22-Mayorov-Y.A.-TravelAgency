using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace TravelAgencyDatabaseImplement.Implements
{
    public class ConditionStorage : IConditionStorage
    {
        public List<ConditionViewModel> GetFullList()
        {
            using (var context = new TravelAgencyDatabase())
            {
                return context.Conditions
                .Select(rec => new ConditionViewModel
                {
                    Id = rec.Id,
                    ConditionName = rec.ConditionName
                })
                .ToList();
            }
        }

        public List<ConditionViewModel> GetFilteredList(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TravelAgencyDatabase())
            {
                return context.Conditions
                .Where(rec => rec.ConditionName.Contains(model.ConditionName))
               .Select(rec => new ConditionViewModel
               {
                   Id = rec.Id,
                   ConditionName = rec.ConditionName
               })
                .ToList();
            }
        }

        public ConditionViewModel GetElement(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TravelAgencyDatabase())
            {
                var condition = context.Conditions
                .FirstOrDefault(rec => rec.ConditionName == model.ConditionName ||
               rec.Id == model.Id);
                return condition != null ?
                new ConditionViewModel
                {
                    Id = condition.Id,
                    ConditionName = condition.ConditionName
                } :
               null;
            }
        }

        public void Insert(ConditionBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                context.Conditions.Add(CreateModel(model, new Condition()));
                context.SaveChanges();
            }
        }

        public void Update(ConditionBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                var element = context.Conditions.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ConditionBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                Condition element = context.Conditions.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Conditions.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Condition CreateModel(ConditionBindingModel model, Condition condition)
        {
            condition.ConditionName = model.ConditionName;
            return condition;
        }
    }
}
