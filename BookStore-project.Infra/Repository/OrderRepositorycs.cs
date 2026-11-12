//using BookStore.API.Models;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;
using System.Data;

namespace BookStore_project.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _dbContext;

        public OrderRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<Order>(
                "ORDER_PACKAGE.GetAllOrders",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Order?> GetOrderByIdAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            return await connection.QueryFirstOrDefaultAsync<Order>(
                "ORDER_PACKAGE.GETORDERBYID",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task CreateOrderAsync(Order order)
        {
            var p = new DynamicParameters();
            p.Add("Customer_Name", order.CustomerName, DbType.String, ParameterDirection.Input);
            p.Add("Phone_Number", order.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("Delivery_Address", order.DeliveryAddress, DbType.String, ParameterDirection.Input);
            p.Add("Order_Status", order.OrderStatus, DbType.String, ParameterDirection.Input);
            p.Add("Payment_Method", order.PaymentMethod, DbType.String, ParameterDirection.Input);
            p.Add("Total_Amount", order.TotalAmount, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_PACKAGE.CREATEORDER",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var p = new DynamicParameters();
            p.Add("ID", order.OrderId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Customer_Name", order.CustomerName, DbType.String, ParameterDirection.Input);
            p.Add("Phone_Number", order.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("Delivery_Address", order.DeliveryAddress, DbType.String, ParameterDirection.Input);
            p.Add("Order_Status", order.OrderStatus, DbType.String, ParameterDirection.Input);
            p.Add("Payment_Method", order.PaymentMethod, DbType.String, ParameterDirection.Input);
            p.Add("Total_Amount", order.TotalAmount, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_PACKAGE.UPDATEORDER",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteOrderAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_PACKAGE.DELETEORDER",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOrderStatusAsync(decimal id, string newStatus)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);
            p.Add("New_Status", newStatus, DbType.String, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_PACKAGE.UpdateOrderStatus",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}