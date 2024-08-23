using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Application.ViewModels
{
    public class RentalViewModel
    {
        [Required(ErrorMessage = "Id do entregador obrigatório.")]
        public Guid DeliveryPersonId { get; set; }

        [Required(ErrorMessage = "Placa obrigatória.")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Plano de aluguel obrigatório.")]
        public RentalPlanEnum RentalPlan { get; set; }
    }
}
