using System;
using System.Threading.Tasks;

namespace MyShop.Worker.Services
{
    public interface IConsumer
    {
        Task SubscribeAsync(string topic, Action<string> message);
    }
}
