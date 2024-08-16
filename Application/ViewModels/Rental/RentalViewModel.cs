using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Application.ViewModels.Rental
{
    public class RentalViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public decimal DailyRate { get; private set; }
        public decimal TotalCost { get; private set; }
        public RentalPlanEnum RentalPlan { get; set; }
        public RentalStatusEnum Status { get; set; }
    }
}
