using DesafioBackEnd.Application.Events;
using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Infra.Data;
using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ.Consumers
{
    public class MotorcycleRegisteredEventHandler
    {
        private readonly IMessageBroker _messageBroker;
        private readonly DataContext _context;

        public MotorcycleRegisteredEventHandler(IMessageBroker messageBroker, DataContext context)
        {
            _messageBroker = messageBroker;

            // Subscrição ao evento de moto registrada
            _messageBroker.Subscribe<MotorcycleRegisteredEvent>("MotorcycleRegisteredQueue", Handle);
            _context = context;
        }

        private void Handle(MotorcycleRegisteredEvent @event)
        {
            // Lógica para processar o evento...
            if (@event.Year == 2024)
            {
                var registration = new Motorcycle2024Registration
                {
                    Id = Guid.NewGuid(),
                    MotorcycleId = @event.MotorcycleId,
                    Year = @event.Year,
                    Model = @event.Model,
                    LicensePlate = @event.LicensePlate,
                    RegisteredAt = DateTime.UtcNow
                };

                _context.Motorcycle2024Registrations.Add(registration);
                _context.SaveChanges();

                Console.WriteLine($"Moto com ano 2024 registrada: {@event.Model} - {@event.LicensePlate}");
               
            }
        }
    }

}
