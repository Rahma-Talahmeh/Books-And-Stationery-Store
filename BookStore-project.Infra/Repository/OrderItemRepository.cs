//using BookStore.API.Models;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;
using System.Data;

namespace BookStore_project.Infra.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IDbContext _dbContext;

        public OrderItemRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<OrderItem>(
                "ORDER_ITEM_PACKAGE.GetAllOrderItems",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<OrderItem?> GetOrderItemByIdAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            return await connection.QueryFirstOrDefaultAsync<OrderItem>(
                "ORDER_ITEM_PACKAGE.GETORDERITEMBYID",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderAsync(decimal orderId)
        {
            var p = new DynamicParameters();
            p.Add("Ord_Id", orderId, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<OrderItem>(
                "ORDER_ITEM_PACKAGE.GetItemsByOrder",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            var p = new DynamicParameters();
            p.Add("Order_Id", orderItem.OrderId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Product_Id", orderItem.ProductId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Quantity", orderItem.Quantity, DbType.Decimal, ParameterDirection.Input);
            p.Add("Unit_Price", orderItem.UnitPrice, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_ITEM_PACKAGE.CREATEORDERITEM",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            var p = new DynamicParameters();
            p.Add("ID", orderItem.OrderItemId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Order_Id", orderItem.OrderId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Product_Id", orderItem.ProductId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Quantity", orderItem.Quantity, DbType.Decimal, ParameterDirection.Input);
            p.Add("Unit_Price", orderItem.UnitPrice, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_ITEM_PACKAGE.UPDATEORDERITEM",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteOrderItemAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "ORDER_ITEM_PACKAGE.DELETEORDERITEM",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}