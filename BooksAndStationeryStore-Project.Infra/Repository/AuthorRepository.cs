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

       
        public Author GetAuthorById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Author> result = _dbContext.Connection.Query<Author>(
                "AUTHOR_PACKAGE.GETAUTHORBYID",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        
        public void CreateAuthor(Author author)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Author_Name", author.AuthorName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Bio", author.Bio, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "AUTHOR_PACKAGE.CREATEAUTHOR",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

       
        public void UpdateAuthor(Author author)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", author.AuthorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("Author_Name", author.AuthorName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("Bio", author.Bio, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "AUTHOR_PACKAGE.UPDATEAUTHOR",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        
        public void DeleteAuthor(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "AUTHOR_PACKAGE.DELETEAUTHOR",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

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
