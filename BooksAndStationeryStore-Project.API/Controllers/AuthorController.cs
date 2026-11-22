using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService _authorService)
        {
            authorService = _authorService;
        }

        [HttpGet]
        public List<Author> GetAllAuthors()
        {
            return authorService.GetAllAuthors();
        }

        [HttpPost]
        public void CreateAuthor(Author author)
        {
            authorService.CreateAuthor(author);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateAuthor(Author author)
        {
            authorService.UpdateAuthor(author);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteAuthor(int id)
        {
            authorService.DeleteAuthor(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Author GetAuthorById(int id)
        {
            return authorService.GetAuthorById(id);
        }

        [HttpGet]
        [Route("GetAllAuthorProducts")]
        public async Task<List<Author>> GetAllAuthorProducts()
        {
            return await authorService.GetAllAuthorProductsAsync();
        }
    }
}
