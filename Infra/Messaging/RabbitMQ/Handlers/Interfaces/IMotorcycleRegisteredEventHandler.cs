using DesafioBackEnd.Application.Events;
using System.Threading.Tasks;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ.Handlers
{
    public interface IMotorcycleRegisteredEventHandler : IMessageHandler<MotorcycleRegisteredEvent>
    {
    }

}
