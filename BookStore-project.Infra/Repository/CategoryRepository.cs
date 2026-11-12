using Dapper;
using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;

namespace BookStore_project.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var p = new DynamicParameters();
            p.Add("p_result", dbType: DbType.Object, direction: ParameterDirection.Output);

            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<Category>("CATEGORY_PACKAGE.GET_ALL_CATEGORIES", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<Category?> GetCategoryByIdAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_id", id, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_result", dbType: DbType.Object, direction: ParameterDirection.Output);

            using var connection = _dbContext.Connection;
            return await connection.QueryFirstOrDefaultAsync<Category>("CATEGORY_PACKAGE.GET_CATEGORY_BY_ID", p, commandType: CommandType.StoredProcedure);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            var p = new DynamicParameters();
            p.Add("p_name", category.CategoryName, DbType.String, ParameterDirection.Input);
            p.Add("p_description", category.Description, DbType.String, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync("CATEGORY_PACKAGE.CREATE_CATEGORY", p, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var p = new DynamicParameters();
            p.Add("p_id", category.CategoryId, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_name", category.CategoryName, DbType.String, ParameterDirection.Input);
            p.Add("p_description", category.Description, DbType.String, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync("CATEGORY_PACKAGE.UPDATE_CATEGORY", p, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteCategoryAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_id", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync("CATEGORY_PACKAGE.DELETE_CATEGORY", p, commandType: CommandType.StoredProcedure);
        }
    }
}