using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DataModel;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public OrderController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            await _context.SaveAsync(order);
            Console.WriteLine($"EVENT: order.created -> {order.Id}");
            return CreatedAtAction(nameof(GetAll), new { id = order.Id }, order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _context.ScanAsync<Order>(new List<Amazon.DynamoDBv2.DocumentModel.ScanCondition>()).GetRemainingAsync();
            return Ok(orders);
        }
    }
}
