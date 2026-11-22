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
    public  class ReviewRepository : IReviewRepository
    {
        private readonly IDbContext _dbContext;

        public ReviewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public List<Review> GetAllReviews()
        {
            IEnumerable<Review> result = _dbContext.Connection.Query<Review>(
                "REVIEW_PACKAGE.GetAllReviews",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public Review GetReviewById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Review> result = _dbContext.Connection.Query<Review>(
                "REVIEW_PACKAGE.GETREVIEWBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        
        public void CreateReview(Review review)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Product_Id", review.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Customer_Name", review.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Rating", review.Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Comments", review.Comments, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "REVIEW_PACKAGE.CREATEREVIEW",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void UpdateReview(Review review)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", review.ReviewId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Product_Id", review.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Customer_Name", review.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Rating", review.Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Comments", review.Comments, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "REVIEW_PACKAGE.UPDATEREVIEW",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void DeleteReview(int id)
        {
            var parameters = new DynamicParameters();
        parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "REVIEW_PACKAGE.DELETEREVIEW",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public List<Review> GetReviewsByProduct(int prodId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", prodId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Review> result = _dbContext.Connection.Query<Review>(
                "REVIEW_PACKAGE.GetReviewsByProduct",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
