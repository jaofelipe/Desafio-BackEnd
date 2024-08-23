using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Services
{
    public interface IRentalService
    {
        Task<Rental> AddAsync(Guid deliveryPersonId, string licensePlate, RentalPlanEnum plan);
        Task<Rental?> CalculateRentalCostAsync(Guid id, DateTime returnDate);
        Task<Rental?> GetByIdIncludedAsync(Guid id);
    }
}
