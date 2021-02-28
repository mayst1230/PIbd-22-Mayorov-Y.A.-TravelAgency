namespace TravelAgencyBusinnesLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int TravelId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}