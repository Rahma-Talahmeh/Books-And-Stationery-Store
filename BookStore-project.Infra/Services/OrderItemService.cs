//using BookStore.API.Models;
using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;

namespace BookStore_project.Core.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _orderItemRepository.GetAllOrderItemsAsync();
        }

        public async Task<OrderItem?> GetOrderItemByIdAsync(decimal id)
        {
            return await _orderItemRepository.GetOrderItemByIdAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderAsync(decimal orderId)
        {
            return await _orderItemRepository.GetItemsByOrderAsync(orderId);
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.CreateOrderItemAsync(orderItem);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.UpdateOrderItemAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(decimal id)
        {
            await _orderItemRepository.DeleteOrderItemAsync(id);
        }
    }
}