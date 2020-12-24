using Microsoft.AspNetCore.Mvc;
using MyShop.API.Commands;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the orders controller");
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateOrderCommand command)
        {
            return Accepted();
        }
    }
}