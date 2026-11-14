
using BookStore_project.Core.Models;

namespace BookStore_project.Core.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(decimal id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(decimal id);
        void UpdateOrderStatus(decimal id, string newStatus);
    }
}