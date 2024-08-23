using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Core.Extensions;

namespace DesafioBackEnd.Application.ViewModels
{
    public class RentalResponseViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public decimal DailyRate { get; set; }
        public decimal TotalCost { get; private set; }
        public RentalPlanEnum RentalPlan { get; set; }
        public string RentalPlanDescription => RentalPlan.GetDescription();
        public DeliveryPersonResponseViewModel? DeliveryPerson { get; set; }
        public MotorcycleResponseViewModel? Motorcycle { get; set; }



    }
}
