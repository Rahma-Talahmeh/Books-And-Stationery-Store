using BookStore_project.Core.Models;
using BookStore_project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public List<Author> GetAllAuthors()
        {
            return _authorService.GetAllAuthors();
        }

        [HttpGet("getById/{id}")]
        public Author GetAuthorById(decimal id)
        {
            return _authorService.GetAuthorById(id);
        }

        [HttpPost]
        public void CreateAuthor(Author author)
        {
            _authorService.CreateAuthor(author);
        }

        [HttpPut]
        public void UpdateAuthor(Author author)
        {
            _authorService.UpdateAuthor(author);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteAuthor(decimal id)
        {
            _authorService.DeleteAuthor(id);
        }
    }
}