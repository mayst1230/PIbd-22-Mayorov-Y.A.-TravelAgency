using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyBusinnesLogic.Enums;
using TravelAgencyListImplement.Models;
using System;
using System.Collections.Generic;

namespace TravelAgencyListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var condition in source.Orders)
            {
                result.Add(CreateModel(condition));
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null || model.DateFrom == null || model.DateTo == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (((model.ClientId.HasValue && order.ClientId == model.ClientId) || 
                !model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date
                && order.DateCreate.Date <= model.DateTo.Value.Date) || 
                (model.FreeOrders.HasValue && model.FreeOrders.Value && order.Status == OrderStatus.Принят) ||
                (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && order.Status == OrderStatus.Выполняется))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var condition in source.Orders)
            {
                if (condition.Id == model.Id)
                {
                    return CreateModel(condition);
                }
            }
            return null;
        }
        public void Insert(OrderBindingModel model)
        {
            Order tempCondition = new Order { Id = 1 };
            foreach (var condition in source.Orders)
            {
                if (condition.Id >= tempCondition.Id)
                {
                    tempCondition.Id = condition.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempCondition));
        }
        public void Update(OrderBindingModel model)
        {
            Order tempCondition = null;
            foreach (var condition in source.Orders)
            {
                if (condition.Id == model.Id)
                {
                    tempCondition = condition;
                }
            }
            if (tempCondition == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempCondition);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ClientId = (int)model.ClientId;
            order.TravelId = model.TravelId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            string travelName = null;
            foreach (var travel in source.Travels)
            {
                if (travel.Id == order.TravelId)
                {
                    travelName = travel.TravelName;
                }
            }

            string clientFIO = null;

            foreach (var client in source.Clients)
            {
                if (client.Id == order.TravelId)
                {
                    clientFIO = client.ClientFIO;
                }
            }

            string implementerFIO = null;

            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == order.ImplementerId)
                {
                    implementerFIO = implementer.ImplementerFIO;
                }
            }

            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ClientFIO = clientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = implementerFIO,
                TravelId = order.TravelId,
                TravelName = travelName,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = order.Status,
                DateImplement = order.DateImplement
            };
        }
    }
}
