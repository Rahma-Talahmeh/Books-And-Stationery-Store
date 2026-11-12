using BookStore_project.Core.IServices;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;

namespace BookStore_project.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(decimal id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _authorRepository.CreateAuthorAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task DeleteAuthorAsync(decimal id)
        {
            await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}