using Confluent.Kafka;
using System.Threading.Tasks;

namespace MyShop.API.Services
{
    public class KakfaProducer : IProducer
    {
        public async Task<string> PublishAsync(string topic, string message)
        {
            var producerConfig = new ProducerConfig
            {
                //BootstrapServers = "broker:9092"
                BootstrapServers = "kafka1:19092"
                //BootstrapServers = "localhost:9092"
                //BootstrapServers = "host.docker.internal:9092"
            };
            using (var p = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                var messg = new Message<string, string> { Key = null, Value = message };
                DeliveryResult<string, string> a = await p.ProduceAsync(topic, messg);
                return a.Key;
            }
        }
    }
}
