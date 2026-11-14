using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;

namespace BookStore_project.Infra.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public Order GetOrderById(decimal id)
        {
            return orderRepository.GetOrderById(id);
        }

        public void CreateOrder(Order order)
        {
            orderRepository.CreateOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(decimal id)
        {
            orderRepository.DeleteOrder(id);
        }

        public void UpdateOrderStatus(decimal id, string newStatus)
        {
            orderRepository.UpdateOrderStatus(id, newStatus);
        }
    }
}