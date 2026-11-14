using BookStore_project.Core.Models;
using BookStore_project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        [HttpGet]
        public List<OrderItem> GetAllOrderItems()
        {
            return orderItemService.GetAllOrderItems();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public OrderItem GetOrderItemById(decimal id)
        {
            return orderItemService.GetOrderItemById(id);
        }
        
        [HttpPost]
        public void CreateOrderItem(OrderItem orderItem)
        {
            orderItemService.CreateOrderItem(orderItem);
        }

        [HttpPut]
        public void UpdateOrderItem(OrderItem orderItem)
        {
            orderItemService.UpdateOrderItem(orderItem);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteOrderItem(decimal id)
        {
            orderItemService.DeleteOrderItem(id);
        }

        [HttpGet]
        [Route("GetItemsByOrder/{ordId}")]
        public List<OrderItem> GetItemsByOrder(decimal ordId)
        {
            return orderItemService.GetItemsByOrder(ordId);
        }
    }
}