using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.HelperModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyBusinnesLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IConditionStorage _conditionStorage;
        private readonly ITravelStorage _travelStorage;
        private readonly IOrderStorage _orderStorage;

        public ReportLogic(ITravelStorage travelStorage, IConditionStorage conditionStorage, IOrderStorage orderStorage)
        {
            _travelStorage = travelStorage;
            _conditionStorage = conditionStorage;
            _orderStorage = orderStorage;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportTravelConditionViewModel> GetTravelConditions()
        {
            var travels = _travelStorage.GetFullList();
            var list = new List<ReportTravelConditionViewModel>();
            foreach (var travel in travels)
            {
                var record = new ReportTravelConditionViewModel
                {
                    TravelName = travel.TravelName,
                    Conditions = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var condition in travel.TravelConditions)
                {
                    record.Conditions.Add(new Tuple<string, int>(condition.Value.Item1, condition.Value.Item2));
                    record.TotalCount += condition.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                TravelName = x.TravelName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveTravelsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                Travels = _travelStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveTravelConditionsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                TravelConditions = GetTravelConditions()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
