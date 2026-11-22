using BooksAndStationeryStore_Project.Core.Common;
using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Repository
{
   public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _dbContext;

        public OrderRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public List<Order> GetAllOrders()
        {
            IEnumerable<Order> result = _dbContext.Connection.Query<Order>(
                "ORDER_PACKAGE.GetAllOrders",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public Order GetOrderById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Order> result = _dbContext.Connection.Query<Order>(
                "ORDER_PACKAGE.GETORDERBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

       
        public void CreateOrder(Order order)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Customer_Name", order.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Phone_Number", order.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Delivery_Address", order.DeliveryAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Order_Status", order.OrderStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Payment_Method", order.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Total_Amount", order.TotalAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_PACKAGE.CREATEORDER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public void UpdateOrder(Order order)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", order.OrderId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Customer_Name", order.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Phone_Number", order.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Delivery_Address", order.DeliveryAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Order_Status", order.OrderStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Payment_Method", order.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Total_Amount", order.TotalAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_PACKAGE.UPDATEORDER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void DeleteOrder(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_PACKAGE.DELETEORDER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void UpdateOrderStatus(int id, string newStatus)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("New_Status", newStatus, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_PACKAGE.UpdateOrderStatus",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Order>> GetAllOrderItemsAsync()
        {
            var parameters = new DynamicParameters();

            var result = await _dbContext.Connection.QueryAsync<Order, OrderItem, Order>(
                "ORDER_PACKAGE.GetAllOrderItems",
                (order, orderItem) =>
                {
                    order.OrderItems.Add(orderItem);
                    return order;
                },
                splitOn: "OrderItemId",
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.GroupBy(o => o.OrderId)
                .Select(group =>
                {
                    var groupedOrder = group.First();
                    groupedOrder.OrderItems = group.Select(o => o.OrderItems.Single()).ToList();
                    return groupedOrder;
                }).ToList();
        }
    }
}
