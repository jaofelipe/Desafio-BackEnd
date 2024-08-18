namespace DesafioBackEnd.Infra.Messaging.RabbitMQ
{
    public interface IMessageHandler<TMessage>
    {
        Task HandleAsync(TMessage @event);
    }

}
