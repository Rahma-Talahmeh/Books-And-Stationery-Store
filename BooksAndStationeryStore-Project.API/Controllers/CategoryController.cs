using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return categoryService.GetAllCategories();
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {
            categoryService.CreateCategory(category);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateCategory(Category category)
        {
            categoryService.UpdateCategory(category);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteCategory(int id)
        {
            categoryService.DeleteCategory(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Category GetCategoryById(int id)
        {
            return categoryService.GetCategoryById(id);
        }

        [HttpGet]
        [Route("GetAllCategoryProducts")]
        public async Task<List<Category>> GetAllCategoryProducts()
        {
            return await categoryService.GetAllCategoryProductsAsync();
        }
    }
}

