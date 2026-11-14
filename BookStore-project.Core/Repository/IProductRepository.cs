using BookStore_project.Core.Models;

namespace BookStore_project.Core.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product? GetProductById(decimal id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(decimal id);
        List<Product> GetAllProductsByCategory(decimal catId);
        List<Product> GetProductsByAuthor(decimal authId);
    }
}