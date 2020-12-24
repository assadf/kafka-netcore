using MyShop.Worker.Services;
using System;
using System.Threading.Tasks;

namespace MyShop.Worker
{
    public class Program
    {
        private const string topic = "kafka-sample";

        public static async Task Main(string[] args)
        {
            Console.Title = "Kafka Sample Consumer";
            Console.WriteLine("Kafka Sample Consumer");
            KakfaConsumer consumer = new KakfaConsumer();
            await consumer.SubscribeAsync(topic, Console.WriteLine);
        }
    }
}
