using BookStore_project.Core.Models;
using BookStore_project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }

        [HttpGet]
        [Route("getByOrderId/{id}")]
        public Order GetOrderById(decimal id)
        {
            return orderService.GetOrderById(id);
        }

        [HttpPost]
        public void CreateOrder(Order order)
        {
            orderService.CreateOrder(order);
        }

        [HttpPut]
        public void UpdateOrder(Order order)
        {
            orderService.UpdateOrder(order);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteOrder(decimal id)
        {
            orderService.DeleteOrder(id);
        }

        [HttpPut]
        [Route("UpdateOrderStatus/{id}/{newStatus}")]
        public void UpdateOrderStatus(decimal id, string newStatus)
        {
            orderService.UpdateOrderStatus(id, newStatus);
        }
    }
}