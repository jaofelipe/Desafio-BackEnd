using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd.Models
{
    public class Motorcycle
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "O ano da moto deve ser válido.")]
        public int Year { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        public Motorcycle(int year, string model, string licensePlate)
        {
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }
     
    }
}