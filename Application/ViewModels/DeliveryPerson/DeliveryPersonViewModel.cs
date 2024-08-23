using DesafioBackEnd.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Application.ViewModels
{

    public class DeliveryPersonViewModel
    {
        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CNPJ � obrigat�rio.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inv�lido. Deve conter 14 d�gitos num�ricos sem pontos, tra�os ou barras.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "A data de nascimento � obrigat�ria.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O n�mero da CNH � obrigat�rio.")]
        public string DriverLicenseNumber { get; set; }

        [Required(ErrorMessage = "O tipo de CNH � obrigat�rio.")]
        public LicenseTypeEnum LicenseType { get; set; }

        public IFormFile? File { get; set; }

    }
}