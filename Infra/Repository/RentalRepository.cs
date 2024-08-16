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


        public async Task<Rental?> GetByIdAsync(Guid id) => await _context.Rentals.FindAsync(id);

      

    }

}
