using BookStore_project.Core.DTO;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;
using BookStore_project.Infra.Repository;

namespace BookStore_project.Infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProductById(decimal id)
        {
            return productRepository.GetProductById(id);
        }

        public void CreateProduct(Product product)
        {
            productRepository.CreateProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(decimal id)
        {
            productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProductsByCategory(decimal catId)
        {
            return productRepository.GetAllProductsByCategory(catId);
        }

        public List<Product> GetProductsByAuthor(decimal authId)
        {
            return productRepository.GetProductsByAuthor(authId);
        }


        public List<Filter> Search(Filter search)
        {
            return productRepository.Search(search);
        }

        // Multi-Mapping

        public Task<List<Product>> GetAllProductReviewsAsync()
        {
            return productRepository.GetAllProductReviewsAsync();
        }
    }
}