using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext DbContext;

        public CategoryRepository(IDbContext dBContext)
        {
            this.DbContext = dBContext;
        }

        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = DbContext.Connection.Query<Category>(
                "Category_Package.GetAllCategories",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetByCategoryId(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Category> result = DbContext.Connection.Query<Category>(
                "Category_Package.GetCategoryById",
                p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void CreateCategory(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Category_Name", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "Category_Package.CREATECATEGORY",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("ID", category.CategoryId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Category_Name", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "Category_Package.UPDATECATEGORY",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute(
                "Category_Package.DELETECATEGORY",
                p,
                commandType: CommandType.StoredProcedure);
        }

        //Multi-Mapping
        public async Task<List<Category>> GetAllCategoryProductsAsync()
        {
            var parameters = new DynamicParameters();

            var result = await DbContext.Connection.QueryAsync<Category, Product, Category>(
                "Category_Package.GetAllCategoryProducts",
                (category, product) =>
                {
                    category.Products.Add(product);
                    return category;
                },
                splitOn: "ProductId",
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.GroupBy(c => c.CategoryId)
                .Select(group =>
                {
                    var groupedCategory = group.First();
                    groupedCategory.Products = group.Select(c => c.Products.Single()).ToList();
                    return groupedCategory;
                }).ToList();
        }
    }
}