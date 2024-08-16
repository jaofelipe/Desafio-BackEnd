using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Interfaces
{
    public interface IMotorcycleService
    {
        Task AddAsync(Motorcycle motorcycle);
        Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate);
        Task<IEnumerable<Motorcycle?>> GetAllAsync();
        Task UpdateLicensePlateAsync(Guid motorcycleId, string newLicensePlate);
        Task<Motorcycle> DeleteAsync(Guid motorcycleId);

    }
}
