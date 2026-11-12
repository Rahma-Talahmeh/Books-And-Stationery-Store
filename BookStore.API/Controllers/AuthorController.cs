using Microsoft.AspNetCore.Mvc;
using BookStore_project.Core.Models;
using BookStore_project.Core.IServices;

namespace BookStore.API.Controllers
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

        // GET: api/author
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // GET: api/author/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(decimal id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound(new { message = "Author not found" });
            }
            return Ok(author);
        }

        // POST: api/author
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            await _authorService.CreateAuthorAsync(author);
            return Ok(new { message = "Author created successfully" });
        }

        // PUT: api/author
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author author)
        {
            await _authorService.UpdateAuthorAsync(author);
            return Ok(new { message = "Author updated successfully" });
        }

        // DELETE: api/author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(decimal id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return Ok(new { message = "Author deleted successfully" });
        }
    }
}