using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Interfaces
{
    public interface IDeliveryPersonService
    {
        Task AddAsync(DeliveryPerson deliveryPerson);
        Task<IEnumerable<DeliveryPerson?>> GetAllAsync();
        Task<string> SaveCnhImageAsync(Guid deliveryPersonId, IFormFile cnhImage);
    }
}
