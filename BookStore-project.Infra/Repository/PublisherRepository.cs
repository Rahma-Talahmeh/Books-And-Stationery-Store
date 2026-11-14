using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IDbContext DbContext;

        public PublisherRepository(IDbContext dBContext)
        {
            this.DbContext = dBContext;
        }

        public List<Publisher> GetAllPublishers()
        {
            IEnumerable<Publisher> result = DbContext.Connection.Query<Publisher>(
                "PUBLISHER_PACKAGE.GetAllPublishers",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Publisher GetPublisherById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Publisher> result = DbContext.Connection.Query<Publisher>(
                "PUBLISHER_PACKAGE.GETPUBLISHERBYID",
                p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void CreatePublisher(Publisher publisher)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Publisher_Name", publisher.PublisherName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Contact_Email", publisher.ContactEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Phone", publisher.Phone, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "PUBLISHER_PACKAGE.CREATEPUBLISHER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            var p = new DynamicParameters();
            p.Add("ID", publisher.PublisherId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Publisher_Name", publisher.PublisherName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Contact_Email", publisher.ContactEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone", publisher.Phone, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "PUBLISHER_PACKAGE.UPDATEPUBLISHER",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeletePublisher(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "PUBLISHER_PACKAGE.DELETEPUBLISHER",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}