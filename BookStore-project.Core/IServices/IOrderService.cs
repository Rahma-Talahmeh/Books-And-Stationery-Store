//using BookStore.API.Models;
using BookStore_project.Core.Models;

namespace BookStore_project.Core.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(decimal id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(decimal id);
        Task UpdateOrderStatusAsync(decimal id, string newStatus);
    }
}