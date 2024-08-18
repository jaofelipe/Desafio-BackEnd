using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Infra.Messaging.RabbitMQ.Handlers;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ.Subscribers
{
    public class MessageSubscriberService : BackgroundService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<MessageSubscriberService> _logger;
        private readonly IMotorcycleRegisteredEventHandler _motorcycleRegisteredEventHandler;

        public MessageSubscriberService(
            IMessageBroker messageBroker,
            ILogger<MessageSubscriberService> logger,
            IMotorcycleRegisteredEventHandler motorcycleRegisteredEventHandler)
        {
            _messageBroker = messageBroker;
            _logger = logger;
            _motorcycleRegisteredEventHandler = motorcycleRegisteredEventHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting message subscriber service.");

            // Configura a inscrição para o evento MotorcycleRegisteredEvent
            _messageBroker.Subscribe("MotorcycleRegistered", _motorcycleRegisteredEventHandler);

            // Mantenha o serviço ativo
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }

}
