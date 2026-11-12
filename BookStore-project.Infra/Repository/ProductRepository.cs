using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;
using System.Data;

namespace BookStore_project.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _dbContext;

        public ProductRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<Product>(
                "PRODUCT_PACKAGE.GetAllProducts",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Product?> GetProductByIdAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            return await connection.QueryFirstOrDefaultAsync<Product>(
                "PRODUCT_PACKAGE.GETPRODUCTBYID",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(decimal categoryId)
        {
            var p = new DynamicParameters();
            p.Add("Cat_Id", categoryId, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<Product>(
                "PRODUCT_PACKAGE.GetALLProductsByCategory",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Product>> GetProductsByAuthorAsync(decimal authorId)
        {
            var p = new DynamicParameters();
            p.Add("Auth_Id", authorId, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<Product>(
                "PRODUCT_PACKAGE.GetProductsByAuthor",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task CreateProductAsync(Product product)
        {
            var p = new DynamicParameters();
            p.Add("Title", product.Title, DbType.String, ParameterDirection.Input);
            p.Add("Description", product.Description, DbType.String, ParameterDirection.Input);
            p.Add("Cover_Image", product.CoverImage, DbType.String, ParameterDirection.Input);
            p.Add("Price", product.Price, DbType.Decimal, ParameterDirection.Input);
            p.Add("Stock_Quantity", product.StockQuantity, DbType.Decimal, ParameterDirection.Input);
            p.Add("Isbn", product.Isbn, DbType.String, ParameterDirection.Input);
            p.Add("Publication_Year", product.PublicationYear, DbType.Decimal, ParameterDirection.Input);
            p.Add("Product_Type", product.ProductType, DbType.String, ParameterDirection.Input);
            p.Add("Is_Featured", product.IsFeatured, DbType.Decimal, ParameterDirection.Input);
            p.Add("Is_New_Arrival", product.IsNewArrival, DbType.Decimal, ParameterDirection.Input);
            p.Add("Is_Best_Seller", product.IsBestSeller, DbType.Decimal, ParameterDirection.Input);
            p.Add("Category_Id", product.CategoryId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Author_Id", product.AuthorId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Publisher_Id", product.PublisherId, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "PRODUCT_PACKAGE.CREATEPRODUCT",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var p = new DynamicParameters();
            p.Add("ID", product.ProductId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Title", product.Title, DbType.String, ParameterDirection.Input);
            p.Add("Description", product.Description, DbType.String, ParameterDirection.Input);
            p.Add("Cover_Image", product.CoverImage, DbType.String, ParameterDirection.Input);
            p.Add("Price", product.Price, DbType.Decimal, ParameterDirection.Input);
            p.Add("Stock_Quantity", product.StockQuantity, DbType.Decimal, ParameterDirection.Input);
            p.Add("Isbn", product.Isbn, DbType.String, ParameterDirection.Input);
            p.Add("Publication_Year", product.PublicationYear, DbType.Decimal, ParameterDirection.Input);
            p.Add("Product_Type", product.ProductType, DbType.String, ParameterDirection.Input);
            p.Add("Is_Featured", product.IsFeatured == true ? 1 : 0, DbType.Decimal, ParameterDirection.Input);
            p.Add("Is_New_Arrival", product.IsNewArrival == true ? 1 : 0, DbType.Decimal, ParameterDirection.Input);
            p.Add("Is_Best_Seller", product.IsBestSeller == true ? 1 : 0, DbType.Decimal, ParameterDirection.Input);
            p.Add("Category_Id", product.CategoryId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Author_Id", product.AuthorId, DbType.Decimal, ParameterDirection.Input);
            p.Add("Publisher_Id", product.PublisherId, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "PRODUCT_PACKAGE.UPDATEPRODUCT",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteProductAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync(
                "PRODUCT_PACKAGE.DELETEPRODUCT",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}