using System.Data;
using BookStore_project.Core.Common;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using Dapper;

namespace BookStore_project.Infra.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContext _dbContext;

        public AuthorRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Author> GetAllAuthors()
        {
            IEnumerable<Author> result = _dbContext.Connection.Query<Author>(
                "AUTHOR_PACKAGE.GetAllAuthors",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Author GetAuthorById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<Author> result = _dbContext.Connection.Query<Author>(
                "AUTHOR_PACKAGE.GETAUTHORBYID",
                p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void CreateAuthor(Author author)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Author_Name", author.AuthorName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Bio", author.Bio, dbType: DbType.String, direction: ParameterDirection.Input);
            //
            _dbContext.Connection.Execute(
                "AUTHOR_PACKAGE.CREATEAUTHOR",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateAuthor(Author author)
        {
            var p = new DynamicParameters();
            p.Add("ID", author.AuthorId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Author_Name", author.AuthorName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Bio", author.Bio, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "AUTHOR_PACKAGE.UPDATEAUTHOR",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteAuthor(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "AUTHOR_PACKAGE.DELETEAUTHOR",
                p,
                commandType: CommandType.StoredProcedure);
        }

        //Multi-Mapping

        public async Task<List<Author>> GetAllAuthorProductsAsync()
        {
            var parameters = new DynamicParameters();

            var result = await _dbContext.Connection.QueryAsync<Author, Product, Author>(
                "AUTHOR_PACKAGE.GetAllAuthorProducts",
                (author, product) =>
                {
                    author.Products.Add(product);
                    return author;
                },
                splitOn: "ProductId",
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.GroupBy(a => a.AuthorId)
                .Select(group =>
                {
                    var groupedAuthor = group.First();
                    groupedAuthor.Products = group.Select(a => a.Products.Single()).ToList();
                    return groupedAuthor;
                }).ToList();
        }
    }
}