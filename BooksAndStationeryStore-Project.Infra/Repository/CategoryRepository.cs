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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>(
                "CATEGORY_PACKAGE.GetAllCategories",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public Category GetCategoryById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Category> result = _dbContext.Connection.Query<Category>(
                "CATEGORY_PACKAGE.GETCATEGORYBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        
        public void CreateCategory(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Category_Name", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "CATEGORY_PACKAGE.CREATECATEGORY",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void UpdateCategory(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", category.CategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Category_Name", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "CATEGORY_PACKAGE.UPDATECATEGORY",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public void DeleteCategory(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "CATEGORY_PACKAGE.DELETECATEGORY",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Category>> GetAllCategoryProductsAsync()
        {
            var parameters = new DynamicParameters();

            var result = await _dbContext.Connection.QueryAsync<Category, Product, Category>(
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
