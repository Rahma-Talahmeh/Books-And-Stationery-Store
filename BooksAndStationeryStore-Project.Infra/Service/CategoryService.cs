using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Repository;
using BooksAndStationeryStore_Project.Core.Service;
using BooksAndStationeryStore_Project.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Infra.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.CreateCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }

        public async Task<List<Category>> GetAllCategoryProductsAsync()
        {
            return await categoryRepository.GetAllCategoryProductsAsync();
        }
    }
}
