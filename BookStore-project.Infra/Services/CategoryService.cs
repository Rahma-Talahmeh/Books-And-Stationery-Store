using BookStore_project.Core.Services;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
//using BookStore_project.Core.Services;

namespace BookStore_project.Infra.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategory()
        {
            return categoryRepository.GetAllCategory();
        }

        public Category GetByCategoryId(decimal id)
        {
            return categoryRepository.GetByCategoryId(id);
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.CreateCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(decimal id)
        {
            categoryRepository.DeleteCategory(id);
        }
    }
}