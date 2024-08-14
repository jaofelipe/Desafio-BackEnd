using DesafioBackEnd.Events;
using DesafioBackEnd.Data;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Repository
{

    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly DataContext _context;

        public MotorcycleRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Motorcycle motorcycle)
        {
            _context.Motorcycles.Add(motorcycle);
            _context.SaveChanges();
        }

        public Motorcycle GetById(Guid id)
        {
            return _context.Motorcycles.Find(id);
        }

        public Motorcycle GetByLicensePlate(string licensePlate)
        {
            return _context.Motorcycles.SingleOrDefault(m => m.LicensePlate == licensePlate);
        }

        public bool ExistsByLicensePlate(string licensePlate)
        {
            return _context.Motorcycles.Any(m => m.LicensePlate == licensePlate);
        }

        public bool HasRentals(Guid motorcycleId)
        {
            // Aqui você faria a verificação de registros de locação
            // Exemplo: return _context.Rentals.Any(r => r.Motorcycle.Id == motorcycleId);
            return false; // Placeholder até que as locações sejam implementadas
        }

        public void Update(Motorcycle motorcycle)
        {
            _context.Motorcycles.Update(motorcycle);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var motorcycle = _context.Motorcycles.Find(id);
            if (motorcycle != null)
            {
                _context.Motorcycles.Remove(motorcycle);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Motorcycle> GetAll()
        {
            return _context.Motorcycles.ToList();
        }

        public IEnumerable<Motorcycle> SearchByLicensePlate(string licensePlate)
        {
            return _context.Motorcycles.Where(m => m.LicensePlate.Contains(licensePlate)).ToList();
        }

        public void Save2024Notification(MotorcycleRegisteredEvent @event)
        {
            _context.MotorcycleRegisteredEvents.Add(@event);
            _context.SaveChanges();
        }
    }

}
