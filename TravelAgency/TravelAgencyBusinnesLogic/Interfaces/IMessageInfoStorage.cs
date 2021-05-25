using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);

        void Insert(MessageInfoBindingModel model);

        List<MessageInfoViewModel> GetMessagesPage(MessageInfoBindingModel model);

        int Count();
    }
}
