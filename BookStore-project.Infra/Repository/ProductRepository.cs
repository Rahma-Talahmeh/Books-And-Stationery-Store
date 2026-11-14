using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext DbContext;

        public ProductRepository(IDbContext dBContext)
        {
            this.DbContext = dBContext;
        }

        public List<Product> GetAllProducts()
        {
            IEnumerable<Product> result = DbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GetAllProducts",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Product GetProductById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Product> result = DbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GETPRODUCTBYID",
                p,
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
            parameters.Add("Stock_Quantity", product.StockQuantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Isbn", product.Isbn, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Publication_Year", product.PublicationYear, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Product_Type", product.ProductType, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Is_Featured", product.IsFeatured, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Is_New_Arrival", product.IsNewArrival, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Is_Best_Seller", product.IsBestSeller, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Category_Id", product.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Author_Id", product.AuthorId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameters.Add("Publisher_Id", product.PublisherId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "PRODUCT_PACKAGE.CREATEPRODUCT",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("ID", product.ProductId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Title", product.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Description", product.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Cover_Image", product.CoverImage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Price", product.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Stock_Quantity", product.StockQuantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Isbn", product.Isbn, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Publication_Year", product.PublicationYear, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Product_Type", product.ProductType, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Is_Featured", product.IsFeatured, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Is_New_Arrival", product.IsNewArrival, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Is_Best_Seller", product.IsBestSeller, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Category_Id", product.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Author_Id", product.AuthorId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Publisher_Id", product.PublisherId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "PRODUCT_PACKAGE.UPDATEPRODUCT",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteProduct(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "PRODUCT_PACKAGE.DELETEPRODUCT",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public List<Product> GetAllProductsByCategory(decimal catId)
        {
            var p = new DynamicParameters();
            p.Add("Cat_Id", catId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Product> result = DbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GetALLProductsByCategory",
                p,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Product> GetProductsByAuthor(decimal authId)
        {
            var p = new DynamicParameters();
            p.Add("Auth_Id", authId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Product> result = DbContext.Connection.Query<Product>(
                "PRODUCT_PACKAGE.GetProductsByAuthor",
                p,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}