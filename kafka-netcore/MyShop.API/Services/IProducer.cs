using System.Threading.Tasks;

namespace MyShop.API.Services
{
    public interface IProducer
    {
        Task<string> PublishAsync(string topic, string message);
    }
}
