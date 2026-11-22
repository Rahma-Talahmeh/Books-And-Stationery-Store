using BooksAndStationeryStore_Project.Core.DTO;
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
    public class ProductService :IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
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

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public List<Product> GetProductsByCategory(int catId)
        {
            return productRepository.GetProductsByCategory(catId);
        }

        public List<Product> GetProductsByAuthor(int authId)
        {
            return productRepository.GetProductsByAuthor(authId);
        }

        public List<Filter> Search(Filter filter)
        {
            return productRepository.Search(filter);
        }
        public async Task<List<Product>> GetAllProductReviewsAsync()
        {
            return await productRepository.GetAllProductReviewsAsync();
        }
    }
}
