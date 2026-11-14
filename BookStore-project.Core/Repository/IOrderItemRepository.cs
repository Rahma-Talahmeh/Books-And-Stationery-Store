using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAllOrderItems();
        OrderItem GetOrderItemById(decimal id);
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(decimal id);
        List<OrderItem> GetItemsByOrder(decimal ordId);
    }
}