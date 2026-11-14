using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbContext DbContext;

        public ReviewRepository(IDbContext dBContext)
        {
            this.DbContext = dBContext;
        }

        public List<Review> GetAllReviews()
        {
            IEnumerable<Review> result = DbContext.Connection.Query<Review>(
                "REVIEW_PACKAGE.GetAllReviews",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Review GetReviewById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Review> result = DbContext.Connection.Query<Review>(
                "REVIEW_PACKAGE.GETREVIEWBYID",
                p,
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

            DbContext.Connection.Execute(
                "REVIEW_PACKAGE.CREATEREVIEW",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateReview(Review review)
        {
            var p = new DynamicParameters();
            p.Add("ID", review.ReviewId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Product_Id", review.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Customer_Name", review.CustomerName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Rating", review.Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Comments", review.Comments, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "REVIEW_PACKAGE.UPDATEREVIEW",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteReview(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "REVIEW_PACKAGE.DELETEREVIEW",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public List<Review> GetReviewsByProduct(decimal prodId)
        {
            var p = new DynamicParameters();
            p.Add("Prod_Id", prodId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Review> result = DbContext.Connection.Query<Review>(
                "REVIEW_PACKAGE.GetReviewsByProduct",
                p,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}