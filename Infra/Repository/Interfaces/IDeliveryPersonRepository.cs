using DesafioBackEnd.Models;

namespace DesafioBackEnd.Infra.Repository
{
    public interface IDeliveryPersonRepository
    {
        Task AddAsync(DeliveryPerson dely);
        Task<bool> ExistsByCnpjAsync(string cnpj);
        Task<IEnumerable<DeliveryPerson?>> GetAllAsync();
        Task<DeliveryPerson?> GetByIdAsync(Guid id);
    }
}
