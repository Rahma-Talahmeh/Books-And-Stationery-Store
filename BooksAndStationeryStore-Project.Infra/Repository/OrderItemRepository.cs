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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IDbContext _dbContext;

        public OrderItemRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public List<OrderItem> GetAllOrderItems()
        {
            IEnumerable<OrderItem> result = _dbContext.Connection.Query<OrderItem>(
                "ORDER_ITEM_PACKAGE.GetAllOrderItems",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public OrderItem GetOrderItemById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<OrderItem> result = _dbContext.Connection.Query<OrderItem>(
                "ORDER_ITEM_PACKAGE.GETORDERITEMBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

       
        public void CreateOrderItem(OrderItem orderItem)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Order_Id", orderItem.OrderId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Product_Id", orderItem.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Quantity", orderItem.Quantity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Unit_Price", orderItem.UnitPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_ITEM_PACKAGE.CREATEORDERITEM",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public void UpdateOrderItem(OrderItem orderItem)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", orderItem.OrderItemId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Order_Id", orderItem.OrderId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Product_Id", orderItem.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Quantity", orderItem.Quantity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Unit_Price", orderItem.UnitPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_ITEM_PACKAGE.UPDATEORDERITEM",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public void DeleteOrderItem(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ORDER_ITEM_PACKAGE.DELETEORDERITEM",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public List<OrderItem> GetItemsByOrder(int ordId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Ord_Id", ordId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<OrderItem> result = _dbContext.Connection.Query<OrderItem>(
                "ORDER_ITEM_PACKAGE.GetItemsByOrder",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
