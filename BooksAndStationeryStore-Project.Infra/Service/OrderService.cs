using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int id)
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

        public void DeleteOrder(int id)
        {
            orderRepository.DeleteOrder(id);
        }

        public void UpdateOrderStatus(int id, string newStatus)
        {
            orderRepository.UpdateOrderStatus(id, newStatus);
        }

        public async Task<List<Order>> GetAllOrderItemsAsync()
        {
            return await orderRepository.GetAllOrderItemsAsync();
        }
    }
}
