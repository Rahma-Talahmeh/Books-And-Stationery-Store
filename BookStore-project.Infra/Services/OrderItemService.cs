
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;

namespace BookStore_project.Infra.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return orderItemRepository.GetAllOrderItems();
        }

        public OrderItem GetOrderItemById(decimal id)
        {
            return orderItemRepository.GetOrderItemById(id);
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            orderItemRepository.CreateOrderItem(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            orderItemRepository.UpdateOrderItem(orderItem);
        }

        public void DeleteOrderItem(decimal id)
        {
            orderItemRepository.DeleteOrderItem(id);
        }

        public List<OrderItem> GetItemsByOrder(decimal ordId)
        {
            return orderItemRepository.GetItemsByOrder(ordId);
        }
    }
}