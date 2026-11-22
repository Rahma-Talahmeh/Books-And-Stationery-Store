using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
   public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository _authorRepository)
        {
            authorRepository = _authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return authorRepository.GetAllAuthors();
        }

        public Author GetAuthorById(int id)
        {
            return authorRepository.GetAuthorById(id);
        }

        public void CreateAuthor(Author author)
        {
            authorRepository.CreateAuthor(author);
        }

        public void UpdateAuthor(Author author)
        {
            authorRepository.UpdateAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            authorRepository.DeleteAuthor(id);
        }

        public async Task<List<Author>> GetAllAuthorProductsAsync()
        {
            return await authorRepository.GetAllAuthorProductsAsync();
        }
    }
}
