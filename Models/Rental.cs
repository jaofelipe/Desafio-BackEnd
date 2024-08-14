using DesafioBackEnd.Enums;

namespace DesafioBackEnd.Models
{
    public class Rental
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public decimal DailyRate { get; private set; }
        public decimal TotalCost { get; private set; }
        public RentalPlanEnum RentalPlan { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
        public Motorcycle Motorcycle { get; set; } // Associa a locação a uma moto
        public RentalStatusEnum Status { get; set; } = RentalStatusEnum.Active;

        public Rental(Motorcycle motorcycle)
        {
            Motorcycle = motorcycle;
        }

        public void CalculateTotalCost(DateTime returnDate)
        {
            int totalDays = (returnDate - StartDate).Days;
            TotalCost = totalDays * DailyRate;

            if (returnDate < EstimatedEndDate)
            {
                int remainingDays = (EstimatedEndDate - returnDate).Days;
                decimal penaltyRate = GetPenaltyRate();
                TotalCost += remainingDays * DailyRate * penaltyRate;
            }
            else if (returnDate > EstimatedEndDate)
            {
                int additionalDays = (returnDate - EstimatedEndDate).Days;
                TotalCost += additionalDays * 50.00m;
            }
        }

        private decimal GetPenaltyRate()
        {
            return RentalPlan switch
            {
                RentalPlanEnum.SevenDays => 0.20m,
                RentalPlanEnum.FifteenDays => 0.40m,
                _ => 0.00m,
            };
        }
    }
}