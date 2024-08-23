using DesafioBackEnd.Application.Interfaces;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ
{
    public class MessageSubscriberService : IHostedService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<MessageSubscriberService> _logger;
        private readonly IMotorcycleRegisteredEventHandler _motorcycleRegisteredEventHandler;
        private readonly string _motorcycleQueueName;

        public MessageSubscriberService(
            IMessageBroker messageBroker,
            ILogger<MessageSubscriberService> logger,
            IMotorcycleRegisteredEventHandler motorcycleRegisteredEventHandler,
            IConfiguration configuration)
        {
            _messageBroker = messageBroker;
            _logger = logger;
            _motorcycleRegisteredEventHandler = motorcycleRegisteredEventHandler;

            _motorcycleQueueName = configuration.GetValue<string>("RabbitMQ:MotorcycleQueueName");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando serviço de subscrição.");

            // Configura a inscrição para o evento MotorcycleRegisteredEvent
            _messageBroker.Subscribe(_motorcycleQueueName, _motorcycleRegisteredEventHandler);

            _logger.LogInformation(string.Format(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"), _motorcycleQueueName));
            // Mantenha o serviço ativo
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        
    }

}
