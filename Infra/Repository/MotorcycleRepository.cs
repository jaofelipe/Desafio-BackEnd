using DesafioBackEnd.Infra.Data;
using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repository
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly DataContext _context;

        public MotorcycleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Motorcycle motorcycle)
        {
            await _context.Motorcycles.AddAsync(motorcycle);
            await _context.SaveChangesAsync();
        }

        public async Task<Motorcycle?> GetByIdAsync(Guid id) => await _context.Motorcycles.FindAsync(id);

        public async Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate) => await _context.Motorcycles.SingleOrDefaultAsync(m => m.LicensePlate == licensePlate);
        public async Task<IEnumerable<Motorcycle?>> GetAllAsync() => await _context.Motorcycles.ToListAsync();

        public async Task<bool> ExistsByLicensePlateAsync(string licensePlate) => await _context.Motorcycles.AnyAsync(m => m.LicensePlate == licensePlate);

        public async Task<bool> HasRentals(Guid motorcycleId) => await _context.Rentals.AnyAsync(r => r.Motorcycle.Id == motorcycleId);

        public async Task UpdateAsync(Motorcycle motorcycle)
        {
            _context.Motorcycles.Update(motorcycle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Motorcycle motorcycle)
        {
            _context.Motorcycles.Remove(motorcycle);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Motorcycle> SearchByLicensePlate(string licensePlate)
        {
            return _context.Motorcycles.Where(m => m.LicensePlate.Contains(licensePlate)).ToList();
        }

    }

}
