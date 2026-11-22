using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
   public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository orderItemRepository;

        public OrderItemService(IOrderItemRepository _orderItemRepository)
        {
            orderItemRepository = _orderItemRepository;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return orderItemRepository.GetAllOrderItems();
        }

        public OrderItem GetOrderItemById(int id)
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

        public void DeleteOrderItem(int id)
        {
            orderItemRepository.DeleteOrderItem(id);
        }

        public List<OrderItem> GetItemsByOrder(int ordId)
        {
            return orderItemRepository.GetItemsByOrder(ordId);
        }
    }
}
