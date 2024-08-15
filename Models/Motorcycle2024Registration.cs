namespace DesafioBackEnd.Models
{
    public class Motorcycle2024Registration
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public Guid MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; }

        public DateTime RegisteredAt { get; set; }

    }
}