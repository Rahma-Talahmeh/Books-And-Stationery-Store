
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;

namespace BookStore_project.Infra.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public Author GetAuthorById(decimal id)
        {
            return _authorRepository.GetAuthorById(id);
        }

        public void CreateAuthor(Author author)
        {
            _authorRepository.CreateAuthor(author);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.UpdateAuthor(author);
        }

        public void DeleteAuthor(decimal id)
        {
            _authorRepository.DeleteAuthor(id);
        }
    }
}