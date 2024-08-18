using DesafioBackEnd.Application.Events;
using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ
{
    public class MotorcycleEventPublisher
    {
        private readonly IMessageBroker _messageBroker; // Interface para RabbitMQ

        public MotorcycleEventPublisher(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public void PublishMotorcycleRegistered(Motorcycle motorcycle)
        {
            var @event = new MotorcycleRegisteredEvent(motorcycle.Id, motorcycle.Year, motorcycle.Model, motorcycle.LicensePlate);
            _messageBroker.Publish("MotorcycleRegistered", @event);
        }
    }

}
