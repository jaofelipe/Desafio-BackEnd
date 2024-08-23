using DesafioBackEnd.Core.Enums;

namespace DesafioBackEnd.Models
{
    public class DeliveryPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public LicenseTypeEnum LicenseType { get; set; }
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        public bool CanRent() => LicenseType == LicenseTypeEnum.A || LicenseType == LicenseTypeEnum.AB;

        public DeliveryPerson(string name, string cnpj, DateTime birthDate, LicenseTypeEnum licenseType, string driverLicenseNumber)
        {
            Name = name;
            Cnpj = cnpj;
            BirthDate = birthDate;
            LicenseType = licenseType;
            DriverLicenseNumber = driverLicenseNumber;
        }

    }
}