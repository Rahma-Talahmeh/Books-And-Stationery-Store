using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IDbContext DbContext;

        public OrderItemRepository(IDbContext dBContext)
        {
            this.DbContext = dBContext;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            IEnumerable<OrderItem> result = DbContext.Connection.Query<OrderItem>(
                "ORDER_ITEM_PACKAGE.GetAllOrderItems",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public OrderItem GetOrderItemById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<OrderItem> result = DbContext.Connection.Query<OrderItem>(
                "ORDER_ITEM_PACKAGE.GETORDERITEMBYID",
                p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Order_Id", orderItem.OrderId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Product_Id", orderItem.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Quantity", orderItem.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Unit_Price", orderItem.UnitPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "ORDER_ITEM_PACKAGE.CREATEORDERITEM",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            var p = new DynamicParameters();
            p.Add("ID", orderItem.OrderItemId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Order_Id", orderItem.OrderId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Product_Id", orderItem.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Quantity", orderItem.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Unit_Price", orderItem.UnitPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "ORDER_ITEM_PACKAGE.UPDATEORDERITEM",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrderItem(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "ORDER_ITEM_PACKAGE.DELETEORDERITEM",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public List<OrderItem> GetItemsByOrder(decimal ordId)
        {
            var p = new DynamicParameters();
            p.Add("Ord_Id", ordId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<OrderItem> result = DbContext.Connection.Query<OrderItem>(
                "ORDER_ITEM_PACKAGE.GetItemsByOrder",
                p,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}