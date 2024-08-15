using DesafioBackEnd.Application.Interfaces;
using global::RabbitMQ.Client;
using global::RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DesafioBackEnd.Infra.Messaging.RabbitMQ
{

    public class RabbitMqMessageBroker : IMessageBroker
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqMessageBroker(string hostname, string username, string password)
        {
            _hostname = hostname;
            _username = username;
            _password = password;

            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish<T>(string queueName, T message)
        {
            _channel.QueueDeclare(queue: queueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: "",
                                  routingKey: queueName,
                                  basicProperties: null,
                                  body: messageBody);
        }

        public void Subscribe<T>(string queueName, Action<T> onMessageReceived)
        {
            _channel.QueueDeclare(queue: queueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var deserializedMessage = JsonSerializer.Deserialize<T>(message);
                onMessageReceived(deserializedMessage);
            };

            _channel.BasicConsume(queue: queueName,
                                  autoAck: true,
                                  consumer: consumer);
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }

}
