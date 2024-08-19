using DesafioBackEnd.Infra.Data;
using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repository
{

    public class DeliveryPersonRepository : IDeliveryPersonRepository
    {
        private readonly DataContext _context;

        public DeliveryPersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DeliveryPerson deliveryPerson)
        {
            await _context.Deliveries.AddAsync(deliveryPerson);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByCnpjAsync(string cnpj) => await _context.Deliveries.AnyAsync(m => m.Cnpj == cnpj);

        public async Task<DeliveryPerson?> GetByIdAsync(Guid id) => await _context.Deliveries.FindAsync(id);
        public async Task<IEnumerable<DeliveryPerson?>> GetAllAsync() => await _context.Deliveries.ToListAsync();




    }

}
