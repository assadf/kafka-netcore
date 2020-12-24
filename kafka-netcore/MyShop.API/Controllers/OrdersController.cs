using Microsoft.AspNetCore.Mvc;
using MyShop.API.Commands;
using MyShop.API.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private const string topic = "kafka-sample";
        private readonly IProducer _producer;

        public OrdersController(IProducer producer)
        {
            _producer = producer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the orders controller");
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateOrderCommand command)
        {
            var message = JsonConvert.SerializeObject(command);
            await _producer.PublishAsync(topic, message);

            return Accepted();
        }
    }
}