using BooksAndStationeryStore_Project.Core.Common;
using BooksAndStationeryStore_Project.Core.DTO;
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
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _dbContext;

        public ProductRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public List<Product> GetAllProducts()
        {
            IEnumerable<Product> result = _dbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GetAllProducts",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public Product GetProductById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Product> result = _dbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GETPRODUCTBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public void CreateProduct(Product product)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Title", product.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Description", product.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Cover_Image", product.CoverImage, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Price", product.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Stock_Quantity", product.StockQuantity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Isbn", product.Isbn, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Publication_Year", product.PublicationYear, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Product_Type", product.ProductType, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Is_Featured", product.IsFeatured == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Is_New_Arrival", product.IsNewArrival == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Is_Best_Seller", product.IsBestSeller == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Category_Id", product.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Author_Id", product.AuthorId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Publisher_Id", product.PublisherId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "PRODUCT_PACKAGE.CREATEPRODUCT",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public void UpdateProduct(Product product)
        {
            var parameters = new DynamicParameters();
            
            parameters.Add("ID", product.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            parameters.Add("Title", product.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Description", product.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Cover_Image", product.CoverImage, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Price", product.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Stock_Quantity", product.StockQuantity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Isbn", product.Isbn, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Publication_Year", product.PublicationYear, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Product_Type", product.ProductType, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Is_Featured", product.IsFeatured == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Is_New_Arrival", product.IsNewArrival == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Is_Best_Seller", product.IsBestSeller == true ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Category_Id", product.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Author_Id", product.AuthorId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Publisher_Id", product.PublisherId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "PRODUCT_PACKAGE.UPDATEPRODUCT",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public void DeleteProduct(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "PRODUCT_PACKAGE.DELETEPRODUCT",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public List<Product> GetProductsByCategory(int catId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Cat_Id", catId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Product> result = _dbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GetALLProductsByCategory",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public List<Product> GetProductsByAuthor(int authId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Auth_Id", authId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Product> result = _dbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GetProductsByAuthor",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Filter> Search(Filter filter)
        {
            var parameter = new DynamicParameters();
            parameter.Add("bTitle", filter.bTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("aName", filter.aName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cName", filter.cName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Filter>(
                "Book_Search_Pkg.SearchBooks",
                parameter,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<Product>> GetAllProductReviewsAsync()
        {
            var parameters = new DynamicParameters();

            var result = await _dbContext.Connection.QueryAsync<Product, Review, Product>(
                "PRODUCT_PACKAGE.GetAllProductReviews",
                (product, review) =>
                {
                    if (review != null && review.ReviewId > 0)
                    {
                        product.Reviews.Add(review);
                    }
                    return product;
                },
                splitOn: "ReviewId",
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.GroupBy(p => p.ProductId)
                .Select(group =>
                {
                    var groupedProduct = group.First();
                    groupedProduct.Reviews = group.SelectMany(p => p.Reviews).Distinct().ToList();
                    return groupedProduct;
                }).ToList();
        }
    }
}
