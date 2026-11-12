//using BookStore.API.Models;
using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GET: api/orderitem
        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var items = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(items);
        }

        // GET: api/orderitem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(decimal id)
        {
            var item = await _orderItemService.GetOrderItemByIdAsync(id);
            if (item == null)
            {
                return NotFound(new { message = "Order item not found" });
            }
            return Ok(item);
        }

        // GET: api/orderitem/order/5
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetItemsByOrder(decimal orderId)
        {
            var items = await _orderItemService.GetItemsByOrderAsync(orderId);
            return Ok(items);
        }

        // POST: api/orderitem
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItem orderItem)
        {
            await _orderItemService.CreateOrderItemAsync(orderItem);
            return Ok(new { message = "Order item created successfully" });
        }

        // PUT: api/orderitem
        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItem orderItem)
        {
            await _orderItemService.UpdateOrderItemAsync(orderItem);
            return Ok(new { message = "Order item updated successfully" });
        }

        // DELETE: api/orderitem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(decimal id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return Ok(new { message = "Order item deleted successfully" });
        }
    }
}