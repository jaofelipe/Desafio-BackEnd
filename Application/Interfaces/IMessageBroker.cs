using DesafioBackEnd.Infra.Messaging.RabbitMQ;

namespace DesafioBackEnd.Application.Interfaces
{
    public interface IMessageBroker
    {
        void Publish<T>(string queueName, T message);
        void Subscribe<T>(string queueName, IMessageHandler<T> handler) where T : class;
    }
}
