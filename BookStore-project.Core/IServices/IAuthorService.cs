
using BookStore_project.Core.Models;

namespace BookStore_project.Core.Services
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(decimal id);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(decimal id);
    }}