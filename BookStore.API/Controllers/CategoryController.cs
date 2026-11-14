using BookStore_project.Core.Models;
using BookStore_project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategory()
        {
            return categoryService.GetAllCategory();
        }

        [HttpGet]
        [Route("getByCategoryId/{id}")]
        public Category GetByCategoryId(decimal id)
        {
            return categoryService.GetByCategoryId(id);
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {
            categoryService.CreateCategory(category);
        }

        [HttpPut]
        public void UpdateCategory(Category category)
        {
            categoryService.UpdateCategory(category);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteCategory(decimal id)
        {
            categoryService.DeleteCategory(id);
        }
    }
}
}