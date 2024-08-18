using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Infra.Messaging.RabbitMQ;
using DesafioBackEnd.Infra.Repository;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly MotorcycleEventPublisher _eventPublisher;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository, MotorcycleEventPublisher eventPublisher)
        {
            _motorcycleRepository = motorcycleRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task AddAsync(Motorcycle motorcycle)
        {
            if (await _motorcycleRepository.ExistsByLicensePlateAsync(motorcycle.LicensePlate))
            {
                throw new InvalidOperationException("Já existe uma motocicleta com essa placa.");
            }

            await _motorcycleRepository.AddAsync(motorcycle);
            _eventPublisher.PublishMotorcycleRegistered(motorcycle);
        }

        public async Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate) => await _motorcycleRepository.GetByLicensePlateAsync(licensePlate);
        public async Task<IEnumerable<Motorcycle?>> GetAllAsync() => await _motorcycleRepository.GetAllAsync();
        
        public async Task UpdateLicensePlateAsync(Guid motorcycleId, string newLicensePlate)
        {
            var motorcycle = await _motorcycleRepository.GetByIdAsync(motorcycleId) ?? throw new KeyNotFoundException("Motocicleta não encontrada.");

            if (await _motorcycleRepository.ExistsByLicensePlateAsync(newLicensePlate))
            {
                throw new InvalidOperationException("Já existe uma motocicleta com essa nova placa.");
            }

            motorcycle.LicensePlate = newLicensePlate;
            await _motorcycleRepository.UpdateAsync(motorcycle);
        }

        public async Task<Motorcycle> DeleteAsync(Guid motorcycleId)
        {
            var motorcycle = await _motorcycleRepository.GetByIdAsync(motorcycleId) ?? throw new KeyNotFoundException("Motocicleta não encontrada.");

            if (await _motorcycleRepository.HasRentals(motorcycleId))
            {
                throw new InvalidOperationException("Não pode ser excluído, pois está locação ativa");
            }

            await _motorcycleRepository.DeleteAsync(motorcycle);

            return motorcycle;
        }
    }
}
