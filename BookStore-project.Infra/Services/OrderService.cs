//using BookStore.API.Models;
using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;

namespace BookStore_project.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(decimal id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(decimal id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }

        public async Task UpdateOrderStatusAsync(decimal id, string newStatus)
        {
            await _orderRepository.UpdateOrderStatusAsync(id, newStatus);
        }
    }
}