using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Service
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        Task<List<Author>> GetAllAuthorProductsAsync();
    }
}
