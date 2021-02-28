using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.Interfaces
{
    public interface ITravelStorage
    {
        List<TravelViewModel> GetFullList();
        List<TravelViewModel> GetFilteredList(TravelBindingModel model);
        TravelViewModel GetElement(TravelBindingModel model);
        void Insert(TravelBindingModel model);
        void Update(TravelBindingModel model);
        void Delete(TravelBindingModel model);
    }
}
