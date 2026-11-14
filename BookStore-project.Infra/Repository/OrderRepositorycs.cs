
using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext DbContext;

        public OrderRepository(IDbContext dBContext)
        {
            this.DbContext = dBContext;
        }

        public List<Order> GetAllOrders()
        {
            IEnumerable<Order> result = DbContext.Connection.Query<Order>(
                "ORDER_PACKAGE.GetAllOrders",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Order GetOrderById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Order> result = DbContext.Connection.Query<Order>(
                "ORDER_PACKAGE.GETORDERBYID",
                p,
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

            DbContext.Connection.Execute(
                "ORDER_PACKAGE.CREATEORDER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateOrder(Order order)
        {
            var p = new DynamicParameters();
            p.Add("ID", order.OrderId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Customer_Name", order.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_Number", order.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Delivery_Address", order.DeliveryAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Order_Status", order.OrderStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Payment_Method", order.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Total_Amount", order.TotalAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "ORDER_PACKAGE.UPDATEORDER",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrder(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "ORDER_PACKAGE.DELETEORDER",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateOrderStatus(decimal id, string newStatus)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("New_Status", newStatus, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "ORDER_PACKAGE.UpdateOrderStatus",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}