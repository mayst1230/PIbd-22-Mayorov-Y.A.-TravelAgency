using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TravelAgencyAppAgency.Models;

namespace TravelAgencyAppAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Privacy");
            }
            return View(APIClient.GetRequest<List<AgencyViewModel>>($"api/agency/getall"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public void Privacy(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Program.Authorization = password == configuration["Password"];

                if (!Program.Authorization)
                {
                    throw new Exception("Неверный пароль");
                }

                Response.Redirect("Index");
                return;
            }

            throw new Exception("Введите пароль");
        }

        public IActionResult Create()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Privacy");
            }
            return View();
        }

        [HttpPost]
        public void Create([Bind("AgencyName, FullNameResponsible")] AgencyBindingModel model)
        {
            if (string.IsNullOrEmpty(model.AgencyName) || string.IsNullOrEmpty(model.FullNameResponsible))
            {
                return;
            }
            model.AgencyTravels = new Dictionary<int, (string, int)>();
            APIClient.PostRequest("api/agency/create", model);
            Response.Redirect("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = APIClient.GetRequest<List<AgencyViewModel>>(
                $"api/agency/getall").FirstOrDefault(rec => rec.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,AgencyName,FullNameResponsible")] AgencyBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            var agency = APIClient.GetRequest<List<AgencyViewModel>>(
                $"api/agency/getall").FirstOrDefault(rec => rec.Id == id);

            model.AgencyTravels = agency.AgencyConditions;

            APIClient.PostRequest("api/agency/update", model);
            return Redirect("~/Home/Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = APIClient.GetRequest<List<AgencyViewModel>>(
                $"api/agency/getall").FirstOrDefault(rec => rec.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            APIClient.PostRequest("api/agency/delete", new AgencyBindingModel { Id = id });
            return Redirect("~/Home/Index");
        }

        public IActionResult AddCondition()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Privacy");
            }
            ViewBag.Agencies = APIClient.GetRequest<List<AgencyViewModel>>("api/agency/getall");
            ViewBag.Conditions = APIClient.GetRequest<List<ConditionViewModel>>($"api/agency/getallconditions");

            return View();
        }

        [HttpPost]
        public IActionResult AddCondition([Bind("AgencyId, ConditionId, Count")] AddConditionsToAgencyBindingModel model)
        {
            if (model.AgencyId == 0 || model.ConditionId == 0 || model.Count <= 0)
            {
                return NotFound();
            }

            var agency = APIClient.GetRequest<List<AgencyViewModel>>(
                "api/agency/getall").FirstOrDefault(rec => rec.Id == model.AgencyId);

            if (agency == null)
            {
                return NotFound();
            }

            var condition = APIClient.GetRequest<List<AgencyViewModel>>(
                "api/agency/getallconditions").FirstOrDefault(rec => rec.Id == model.ConditionId);

            if (condition == null)
            {
                return NotFound();
            }

            APIClient.PostRequest("api/agency/addcondition", model);
            return Redirect("~/Home/Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
