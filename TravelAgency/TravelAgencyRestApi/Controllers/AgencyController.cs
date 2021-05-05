using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyBusinnesLogic.BusinessLogics;

namespace TravelAgencyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly AgencyLogic agencyLogic;
        private readonly ConditionLogic conditionLogic;

        public AgencyController(AgencyLogic agencyLogic, ConditionLogic conditionLogic)
        {
            this.agencyLogic = agencyLogic;
            this.conditionLogic = conditionLogic;
        }

        public List<AgencyViewModel> GetAll() => agencyLogic.Read(null);

        public List<ConditionViewModel> GetAllConditions() => conditionLogic.Read(null);

        [HttpPost]
        public void Create(AgencyBindingModel model) => agencyLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Update(AgencyBindingModel model) => agencyLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(AgencyBindingModel model) => agencyLogic.Delete(model);

        [HttpPost]
        public void AddCondition(AddConditionsToAgencyBindingModel model) => agencyLogic.AddConditions(model);
    }
}
