using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.IServices;

namespace BookStore_project.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product?> GetProductByIdAsync(decimal id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(decimal categoryId)
        {
            return await _productRepository.GetAllProductsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsByAuthorAsync(decimal authorId)
        {
            return await _productRepository.GetProductsByAuthorAsync(authorId);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(decimal id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}