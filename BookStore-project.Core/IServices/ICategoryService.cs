using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;

namespace BookStore_project.Core.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        Category GetByCategoryId(decimal id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(decimal id);

        //Multi-Mapping
        Task<List<Category>> GetAllCategoryProductsAsync();

        
    }
}