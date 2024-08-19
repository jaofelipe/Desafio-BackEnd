using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Services
{
    public interface IRentalService
    {
        Task<Rental> AddAsync(Guid deliveryPersonId, Guid motorcycleId, RentalPlanEnum plan);
    }
}
