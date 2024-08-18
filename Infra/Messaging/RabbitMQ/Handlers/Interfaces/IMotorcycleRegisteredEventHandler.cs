using DesafioBackEnd.Application.Events;
using System.Threading.Tasks;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ
{
    public interface IMotorcycleRegisteredEventHandler : IMessageHandler<MotorcycleRegisteredEvent>
    {
    }

}
