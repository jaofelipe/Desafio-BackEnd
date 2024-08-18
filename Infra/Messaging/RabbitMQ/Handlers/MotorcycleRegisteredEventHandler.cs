using DesafioBackEnd.Application.Events;
using DesafioBackEnd.Infra.Data;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ
{
    public class MotorcycleRegisteredEventHandler : IMotorcycleRegisteredEventHandler
    {
        private readonly DataContext _context;
        private readonly ILogger<MotorcycleRegisteredEventHandler> _logger;

        public MotorcycleRegisteredEventHandler(DataContext context, ILogger<MotorcycleRegisteredEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task HandleAsync(MotorcycleRegisteredEvent @event)
        {
            if (@event.Year == 2024)
            {
                var registration = new Motorcycle2024Registration
                {
                    MotorcycleId = @event.MotorcycleId,
                    Year = @event.Year,
                    Model = @event.Model,
                    LicensePlate = @event.LicensePlate,
                    RegisteredAt = DateTime.UtcNow
                };

                _context.Motorcycle2024Registrations.Add(registration);

                try
                {
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Motocicleta com ID {MotorcycleId} salvo para ano de 2024.", @event.MotorcycleId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao salvar motocicleta com ID {MotorcycleId} para o ano de 2024.", @event.MotorcycleId);
                }
            }
        }
    }
}
