using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyDatabaseImplement.Models;
using TravelAgencyBusinnesLogic.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (TravelAgencyDatabase context = new TravelAgencyDatabase())
            {
                return context.Orders
                .Include(rec => rec.Travel)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    TravelId = rec.TravelId,
                    TravelName = rec.Travel.TravelName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (TravelAgencyDatabase context = new TravelAgencyDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Travel)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .Where(rec => rec.TravelId.Equals(model.TravelId)
                    || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date)
                    || (model.ClientId.HasValue && rec.ClientId == model.ClientId)
                    || (model.FreeOrders.HasValue && model.FreeOrders.Value && !rec.ImplementerId.HasValue)
                    || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ClientId = rec.ClientId,
                        ClientFIO = rec.Client.ClientFIO,
                        TravelId = rec.TravelId,
                        TravelName = rec.Travel.TravelName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        ImplementerId = rec.ImplementerId,
                        ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                        DateImplement = rec.DateImplement
                    }).ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (TravelAgencyDatabase context = new TravelAgencyDatabase())
            {
                var order = context.Orders
                    .Include(rec => rec.Travel)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    ClientFIO = order.Client.ClientFIO,
                    TravelId = order.TravelId,
                    TravelName = order.Travel.TravelName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    ImplementerId = order.ImplementerId,
                    ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
                    DateImplement = order.DateImplement
                } : null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (TravelAgencyDatabase context = new TravelAgencyDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (TravelAgencyDatabase context = new TravelAgencyDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }
                CreateModel(model, order);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (TravelAgencyDatabase context = new TravelAgencyDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ClientId = (int)model.ClientId;
            order.TravelId = model.TravelId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.ImplementerId = model.ImplementerId;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}