namespace DesafioBackEnd.Application.Events
{
    public class MotorcycleRegisteredEvent
    {
        public Guid MotorcycleId { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public MotorcycleRegisteredEvent(Guid motorcycleId, int year, string model, string licensePlate)
        {
            MotorcycleId = motorcycleId;
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }
    }

}
