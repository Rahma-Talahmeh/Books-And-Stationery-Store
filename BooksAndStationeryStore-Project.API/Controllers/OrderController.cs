using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }

        [HttpPost]
        public void CreateOrder(Order order)
        {
            orderService.CreateOrder(order);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateOrder(Order order)
        {
            orderService.UpdateOrder(order);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Order GetOrderById(int id)
        {
            return orderService.GetOrderById(id);
        }

        [HttpGet]
        [Route("GetAllOrderItems")]
        public async Task<List<Order>> GetAllOrderItems()
        {
            return await orderService.GetAllOrderItemsAsync();
        }
    }
}

