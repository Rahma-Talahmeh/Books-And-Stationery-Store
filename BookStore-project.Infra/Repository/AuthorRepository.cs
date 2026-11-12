using Dapper;
using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;

namespace BookStore_project.Infra.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContext _dbContext;

        public AuthorRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            var p = new DynamicParameters();
            p.Add("p_result", dbType: DbType.Object, direction: ParameterDirection.Output);

            using var connection = _dbContext.Connection;
            return await connection.QueryAsync<Author>("AUTHOR_PACKAGE.GET_ALL_AUTHORS", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<Author?> GetAuthorByIdAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_id", id, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_result", dbType: DbType.Object, direction: ParameterDirection.Output);

            using var connection = _dbContext.Connection;
            return await connection.QueryFirstOrDefaultAsync<Author>("AUTHOR_PACKAGE.GET_AUTHOR_BY_ID", p, commandType: CommandType.StoredProcedure);
        }

        public async Task CreateAuthorAsync(Author author)
        {
            var p = new DynamicParameters();
            p.Add("p_name", author.AuthorName, DbType.String, ParameterDirection.Input);
            p.Add("p_bio", author.Bio, DbType.String, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync("AUTHOR_PACKAGE.CREATE_AUTHOR", p, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var p = new DynamicParameters();
            p.Add("p_id", author.AuthorId, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_name", author.AuthorName, DbType.String, ParameterDirection.Input);
            p.Add("p_bio", author.Bio, DbType.String, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync("AUTHOR_PACKAGE.UPDATE_AUTHOR", p, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAuthorAsync(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_id", id, DbType.Decimal, ParameterDirection.Input);

            using var connection = _dbContext.Connection;
            await connection.ExecuteAsync("AUTHOR_PACKAGE.DELETE_AUTHOR", p, commandType: CommandType.StoredProcedure);
        }
    }
}