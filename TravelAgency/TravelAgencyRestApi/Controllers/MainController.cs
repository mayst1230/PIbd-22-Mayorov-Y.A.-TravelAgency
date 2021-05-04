using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using TravelAgencyBusinnesLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly TravelLogic _travel;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, TravelLogic travel, OrderLogic main)
        {
            _order = order;
            _travel = travel;
            _main = main;
        }

        [HttpGet]
        public List<TravelViewModel> GetTravelList() => _travel.Read(null)?.ToList();

        [HttpGet]
        public TravelViewModel GetTravel(int travelId) => _travel.Read(new TravelBindingModel
        { Id = travelId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
