using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Service
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAllOrderItems();
        OrderItem GetOrderItemById(int id);
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int id);
        List<OrderItem> GetItemsByOrder(int ordId);
    }
}
