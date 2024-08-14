using DesafioBackEnd.Repository;
using GerenciadorTarefas.Models;

namespace DesafioBackEnd.Services
{
    public class MotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly MotorcycleEventPublisher _eventPublisher;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository, MotorcycleEventPublisher eventPublisher)
        {
            _motorcycleRepository = motorcycleRepository;
            _eventPublisher = eventPublisher;
        }

        public void RegisterMotorcycle(Motorcycle motorcycle)
        {
            if (_motorcycleRepository.ExistsByLicensePlate(motorcycle.LicensePlate))
            {
                throw new InvalidOperationException("A motorcycle with this license plate already exists.");
            }

            _motorcycleRepository.Add(motorcycle);
            _eventPublisher.PublishMotorcycleRegistered(motorcycle);
        }

        public Motorcycle GetByLicensePlate(string licensePlate)
        {
            return _motorcycleRepository.GetByLicensePlate(licensePlate);
        }

        public void UpdateLicensePlate(Guid motorcycleId, string newLicensePlate)
        {
            var motorcycle = _motorcycleRepository.GetById(motorcycleId) ?? throw new KeyNotFoundException("Motorcycle not found.");

            if (_motorcycleRepository.ExistsByLicensePlate(newLicensePlate))
            {
                throw new InvalidOperationException("A motorcycle with this new license plate already exists.");
            }

            motorcycle.LicensePlate = newLicensePlate;
            _motorcycleRepository.Update(motorcycle);
        }

        public void DeleteMotorcycle(Guid motorcycleId)
        {
            var motorcycle = _motorcycleRepository.GetById(motorcycleId) ?? throw new KeyNotFoundException("Motorcycle not found.");

            if (_motorcycleRepository.HasRentals(motorcycleId))
            {
                throw new InvalidOperationException("Cannot delete a motorcycle with rental records.");
            }

            _motorcycleRepository.Delete(motorcycleId);
        }
    }
}
