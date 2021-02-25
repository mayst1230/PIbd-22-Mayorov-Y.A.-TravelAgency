using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyFileImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
        private readonly FileDataListSingleton source;

        public TravelStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<TravelViewModel> GetFullList()
        {
            return source.Travels
            .Select(CreateModel)
            .ToList();
        }
        public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Travels
            .Where(rec => rec.TravelName.Contains(model.TravelName))
            .Select(CreateModel)
            .ToList();
        }
        public TravelViewModel GetElement(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var travel = source.Travels
            .FirstOrDefault(rec => rec.TravelName == model.TravelName || rec.Id
           == model.Id);
            return travel != null ? CreateModel(travel) : null;
        }

        public void Insert(TravelBindingModel model)
        {
            int maxId = source.Travels.Count > 0 ? source.Conditions.Max(rec => rec.Id)
: 0;
            var element = new Travel
            {
                Id = maxId + 1,
                TravelConditions = new Dictionary<int, int>()
            };
            source.Travels.Add(CreateModel(model, element));
        }

        public void Update(TravelBindingModel model)
        {
            var element = source.Travels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(TravelBindingModel model)
        {
            Travel element = source.Travels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Travels.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Travel CreateModel(TravelBindingModel model, Travel travel)
        {
            travel.TravelName = model.TravelName;
            travel.Price = model.Price;
            // удаляем убранные
            foreach (var key in travel.TravelConditions.Keys.ToList())
            {
                if (!model.TravelConditions.ContainsKey(key))
                {
                    travel.TravelConditions.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var condition in model.TravelConditions)
            {
                if (travel.TravelConditions.ContainsKey(condition.Key))
                {
                    travel.TravelConditions[condition.Key] =
                   model.TravelConditions[condition.Key].Item2;
                }
                else
                {
                    travel.TravelConditions.Add(condition.Key,
                   model.TravelConditions[condition.Key].Item2);
                }
            }
            return travel;
        }

        private TravelViewModel CreateModel(Travel travel)
        {
            return new TravelViewModel
            {
                Id = travel.Id,
                TravelName = travel.TravelName,
                Price = travel.Price,
                TravelConditions = travel.TravelConditions.ToDictionary(recPC => recPC.Key, recPC =>(source.Conditions.FirstOrDefault(recC => recC.Id == recPC.Key)?.ConditionName, recPC.Value))
            };
        }
    }
}