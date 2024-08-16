using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Core.Enums;
using DesafioBackEnd.Infra.Messaging.RabbitMQ.Publishers;
using DesafioBackEnd.Infra.Repository;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Services
{
    public interface IRentalService
    {
        Task<Rental> AddAsync(Guid deliveryPersonId, Guid motorcycleId, RentalPlanEnum plan);
    }
}
