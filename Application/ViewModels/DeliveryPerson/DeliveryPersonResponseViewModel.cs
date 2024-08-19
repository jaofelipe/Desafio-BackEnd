using DesafioBackEnd.Core.Enums;

namespace DesafioBackEnd.Application.ViewModels
{
    public class DeliveryPersonResponseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public LicenseTypeEnum LicenseType { get; set; }

        public string? FilePath { get; set; }


    }
}