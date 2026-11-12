using Microsoft.AspNetCore.Mvc;
using BookStore_project.Core.Models;
using BookStore_project.Core.IServices;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(decimal id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return Ok(new { message = "Category created successfully" });
        }

        // PUT: api/category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return Ok(new { message = "Category updated successfully" });
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(decimal id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}