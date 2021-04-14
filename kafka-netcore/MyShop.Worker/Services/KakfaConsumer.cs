using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Worker.Services
{
    class KakfaConsumer : IConsumer
    {
        public Task SubscribeAsync(string topic, Action<string> message)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "kafka1:19092"
            };

            using (var cons = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                cons.Subscribe(topic);
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (true)
                        try
                        {
                            var cr = cons.Consume(cts.Token);
                            message(cr.Message.Value);
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine(e);
                        }
                }
                catch (Exception)
                {
                    cons.Close();
                }
            }

            return Task.CompletedTask;
        }
    }
}
