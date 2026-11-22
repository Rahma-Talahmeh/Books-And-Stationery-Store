using BooksAndStationeryStore_Project.Core.DTO;
using BooksAndStationeryStore_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndStationeryStore_Project.Core.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetProductsByCategory(int catId);
        List<Product> GetProductsByAuthor(int authId);

        public List<Filter> Search(Filter filter);
        Task<List<Product>> GetAllProductReviewsAsync();
    }
}
