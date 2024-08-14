using DesafioBackEnd.Events;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Repository
{
    public interface IMotorcycleRepository
    {
        void Add(Motorcycle motorcycle);
        Motorcycle GetById(Guid id);
        Motorcycle GetByLicensePlate(string licensePlate);
        bool ExistsByLicensePlate(string licensePlate);
        bool HasRentals(Guid motorcycleId);
        void Update(Motorcycle motorcycle);
        void Delete(Guid id);
        IEnumerable<Motorcycle> GetAll();
        IEnumerable<Motorcycle> SearchByLicensePlate(string licensePlate);
        void Save2024Notification(MotorcycleRegisteredEvent @event);
    }
}
