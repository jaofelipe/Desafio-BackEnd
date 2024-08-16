using DesafioBackEnd.Models;

namespace DesafioBackEnd.Infra.Repository
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
        Task<Rental?> GetByIdAsync(Guid id);
    }
}
