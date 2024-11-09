using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Services;

namespace OrderProcessing.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            try
            {
                var order = await _orderService.CreateOrderAsync(request.CustomerId, request.ProductIds);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            try
            {
                var totalPrice = await _orderService.GetTotalPriceAsync(id);
                return Ok(new { TotalPrice = totalPrice });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}