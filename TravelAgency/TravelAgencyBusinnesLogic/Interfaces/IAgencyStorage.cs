using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.Interfaces
{
    public interface IAgencyStorage
    {
        List<AgencyViewModel> GetFullList();
        List<AgencyViewModel> GetFilteredList(AgencyBindingModel model);
        AgencyViewModel GetElement(AgencyBindingModel model);
        void Insert(AgencyBindingModel model);
        void Update(AgencyBindingModel model);
        void Delete(AgencyBindingModel model);
        bool TakeFromTravelAgency(Dictionary<int, (string, int)> conditions, int travelCount);
    }
}
