using BookStore_project.Core.Models;

namespace BookStore_project.Core.Services
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAllOrderItems();
        OrderItem GetOrderItemById(decimal id);
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(decimal id);
        List<OrderItem> GetItemsByOrder(decimal ordId);
    }
}