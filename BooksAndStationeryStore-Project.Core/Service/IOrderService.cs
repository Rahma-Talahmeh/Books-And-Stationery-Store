using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Service
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrderStatus(int id, string newStatus);

        Task<List<Order>> GetAllOrderItemsAsync();
    }
}
