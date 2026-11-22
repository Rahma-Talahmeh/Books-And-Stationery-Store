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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IDbContext _dbContext;

        public PublisherRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public List<Publisher> GetAllPublishers()
        {
            IEnumerable<Publisher> result = _dbContext.Connection.Query<Publisher>(
                "PUBLISHER_PACKAGE.GetAllPublishers",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

       
        public Publisher GetPublisherById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Publisher> result = _dbContext.Connection.Query<Publisher>(
                "PUBLISHER_PACKAGE.GETPUBLISHERBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        
        public void CreatePublisher(Publisher publisher)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Publisher_Name", publisher.PublisherName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Contact_Email", publisher.ContactEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Phone", publisher.Phone, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "PUBLISHER_PACKAGE.CREATEPUBLISHER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public void UpdatePublisher(Publisher publisher)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", publisher.PublisherId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Publisher_Name", publisher.PublisherName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Contact_Email", publisher.ContactEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Phone", publisher.Phone, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "PUBLISHER_PACKAGE.UPDATEPUBLISHER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void DeletePublisher(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "PUBLISHER_PACKAGE.DELETEPUBLISHER",
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
