using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetByCategoryId(decimal id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(decimal id);
    }
}