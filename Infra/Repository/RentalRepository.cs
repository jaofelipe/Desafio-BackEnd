using DesafioBackEnd.Infra.Data;
using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repository
{

    public class RentalRepository : IRentalRepository
    {
        private readonly DataContext _context;

        public RentalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }


        public async Task<Rental?> GetByIdIncludedAsync(Guid id) {
            return await _context.Rentals
                .Include(x => x.Motorcycle)
                .Include(x => x.DeliveryPerson)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rental?> GetByIdAsync(Guid id)
        {
            return await _context.Rentals
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}
