using DesafioBackEnd.Application.Events;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Infra.Repository
{
    public interface IMotorcycleRepository
    {
        Task AddAsync(Motorcycle motorcycle);
        Task<Motorcycle?> GetByIdAsync(Guid id);
        void Save2024Notification(MotorcycleRegisteredEvent @event);
        Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate);
        Task<bool> ExistsByLicensePlateAsync(string licensePlate);
        Task UpdateAsync(Motorcycle motorcycle);
        Task DeleteAsync(Motorcycle motorcycle);
        Task<bool> HasRentals(Guid motorcycleId);
        Task<IEnumerable<Motorcycle?>> GetAllAsync();
    }
}
