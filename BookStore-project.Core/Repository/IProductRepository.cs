using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(decimal id);
        Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(decimal categoryId);
        Task<IEnumerable<Product>> GetProductsByAuthorAsync(decimal authorId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(decimal id);
    }
}