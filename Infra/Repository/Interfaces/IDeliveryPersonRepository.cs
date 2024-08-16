using DesafioBackEnd.Models;

namespace DesafioBackEnd.Infra.Repository
{
    public interface IDeliveryPersonRepository
    {
        Task AddAsync(DeliveryPerson dely);
        Task<DeliveryPerson?> GetByIdAsync(Guid id);
    }
}
