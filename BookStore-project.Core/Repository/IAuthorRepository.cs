using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(decimal id);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(decimal id);
    }
}