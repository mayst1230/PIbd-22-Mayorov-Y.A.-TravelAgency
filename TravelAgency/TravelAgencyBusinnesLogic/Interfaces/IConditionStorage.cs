using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.Interfaces
{
    public interface IConditionStorage
    {
        List<ConditionViewModel> GetFullList();
        List<ConditionViewModel> GetFilteredList(ConditionBindingModel model);
        ConditionViewModel GetElement(ConditionBindingModel model);
        void Insert(ConditionBindingModel model);
        void Update(ConditionBindingModel model);
        void Delete(ConditionBindingModel model);
    }
}
