//using BookStore.API.Models;
using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(decimal id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            await _orderService.CreateOrderAsync(order);
            return Ok(new { message = "Order created successfully" });
        }

        // PUT: api/order
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            await _orderService.UpdateOrderAsync(order);
            return Ok(new { message = "Order updated successfully" });
        }

        // PATCH: api/order/5/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(decimal id, [FromBody] string newStatus)
        {
            await _orderService.UpdateOrderStatusAsync(id, newStatus);
            return Ok(new { message = "Order status updated successfully" });
        }

        // DELETE: api/order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(decimal id)
        {
            await _orderService.DeleteOrderAsync(id);
            return Ok(new { message = "Order deleted successfully" });
        }
    }
}