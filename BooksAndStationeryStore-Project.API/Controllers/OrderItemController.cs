using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService orderItemService;

        public OrderItemController(IOrderItemService _orderItemService)
        {
            orderItemService = _orderItemService;
        }

        [HttpGet]
        public List<OrderItem> GetAllOrderItems()
        {
            return orderItemService.GetAllOrderItems();
        }

        [HttpPost]
        public void CreateOrderItem(OrderItem orderItem)
        {
            orderItemService.CreateOrderItem(orderItem);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateOrderItem(OrderItem orderItem)
        {
            orderItemService.UpdateOrderItem(orderItem);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteOrderItem(int id)
        {
            orderItemService.DeleteOrderItem(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public OrderItem GetOrderItemById(int id)
        {
            return orderItemService.GetOrderItemById(id);
        }
    }
}

