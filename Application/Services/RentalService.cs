using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Infra.Repository;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IDeliveryPersonRepository _deliveryPersonRepository;

        public RentalService(IMotorcycleRepository motorcycleRepository, IRentalRepository rentalRepository, IDeliveryPersonRepository deliveryPersonRepository)
        {
            _motorcycleRepository = motorcycleRepository;
            _rentalRepository = rentalRepository;
            _deliveryPersonRepository = deliveryPersonRepository;
        }

        public async Task<Rental> AddAsync(Guid deliveryPersonId, Guid motorcycleId, RentalPlanEnum plan)
        {
            var deliveryPerson = await _deliveryPersonRepository.GetByIdAsync(deliveryPersonId) ?? throw new KeyNotFoundException("Entregador não encontrado.");
            var motorcycle = await _motorcycleRepository.GetByIdAsync(motorcycleId) ?? throw new KeyNotFoundException("Motocicleta não encontrada.");

            if (!deliveryPerson.CanRent())
                throw new InvalidOperationException("Somente entregadores com licença do tipo A podem alugar uma motocicleta");

            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = startDate.AddDays(GetRentalDays(plan));
            decimal dailyRate = GetDailyRate(plan);

            var rental = new Rental
            {
                StartDate = startDate,
                EstimatedEndDate = endDate,
                DailyRate = dailyRate,
                RentalPlan = plan,
                DeliveryPersonId = deliveryPersonId,
                MotorcycleId = motorcycleId,
            };

            await _rentalRepository.AddAsync(rental);
            
            return rental;
        }

      

        public void ReturnMotorcycle(Rental rental, DateTime returnDate)
        {
            rental.CalculateTotalCost(returnDate);
            rental.EndDate = returnDate;
            rental.Status = RentalStatusEnum.Completed;
        }

        #region Méotodos privados
        private static int GetRentalDays(RentalPlanEnum plan)
        {
            return plan switch
            {
                RentalPlanEnum.SevenDays => 7,
                RentalPlanEnum.FifteenDays => 15,
                RentalPlanEnum.ThirtyDays => 30,
                RentalPlanEnum.FortyFiveDays => 45,
                RentalPlanEnum.FiftyDays => 50,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static decimal GetDailyRate(RentalPlanEnum plan)
        {
            return plan switch
            {
                RentalPlanEnum.SevenDays => 30.00m,
                RentalPlanEnum.FifteenDays => 28.00m,
                RentalPlanEnum.ThirtyDays => 22.00m,
                RentalPlanEnum.FortyFiveDays => 20.00m,
                RentalPlanEnum.FiftyDays => 18.00m,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        #endregion
    }
}
