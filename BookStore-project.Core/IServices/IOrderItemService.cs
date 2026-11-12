//using BookStore.API.Models;
using BookStore_project.Core.Models;

namespace BookStore_project.Core.IServices
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem?> GetOrderItemByIdAsync(decimal id);
        Task<IEnumerable<OrderItem>> GetItemsByOrderAsync(decimal orderId);
        Task CreateOrderItemAsync(OrderItem orderItem);
        Task UpdateOrderItemAsync(OrderItem orderItem);
        Task DeleteOrderItemAsync(decimal id);
    }
}