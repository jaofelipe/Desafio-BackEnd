using DesafioBackEnd.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Application.ViewModels
{
    public class DeliveryPersonViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Cnpj { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public string DriverLicenseNumber { get; set; }

        [Required]
        public LicenseTypeEnum LicenseType { get; set; }

        public IFormFile? File { get; set; }


    }
}