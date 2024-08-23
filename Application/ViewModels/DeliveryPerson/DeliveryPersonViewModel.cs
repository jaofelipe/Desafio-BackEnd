using DesafioBackEnd.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Application.ViewModels
{

    public class DeliveryPersonViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inválido. Deve conter 14 dígitos numéricos sem pontos, traços ou barras.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O número da CNH é obrigatório.")]
        public string DriverLicenseNumber { get; set; }

        [Required(ErrorMessage = "O tipo de CNH é obrigatório.")]
        public LicenseTypeEnum LicenseType { get; set; }

        public IFormFile? File { get; set; }

    }
}