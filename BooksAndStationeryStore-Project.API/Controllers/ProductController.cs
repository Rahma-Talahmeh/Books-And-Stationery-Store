using BooksAndStationeryStore_Project.Core.DTO;
using BooksAndStationeryStore_Project.Core.Models;
using BooksAndStationeryStore_Project.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndStationeryStore_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return productService.GetAllProducts();
        }

        [HttpPost]
        public void CreateProduct(Product product)
        {
            productService.CreateProduct(product);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public void UpdateProduct(Product product)
        {
            productService.UpdateProduct(product);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Product GetProductById(int id)
        {
            return productService.GetProductById(id);
        }

        [HttpGet]
        [Route("GetByCategory/{catId}")]
        public List<Product> GetProductsByCategory(int catId)
        {
            return productService.GetProductsByCategory(catId);
        }

        [HttpGet]
        [Route("GetByAuthor/{authId}")]
        public List<Product> GetProductsByAuthor(int authId)
        {
            return productService.GetProductsByAuthor(authId);
        }

        [HttpPost]
        [Route("Search")] 
        public List<Filter> Search([FromBody] Filter filter)
        {
            return productService.Search(filter);
        }

        [HttpGet]
        [Route("GetAllProductReviews")]
        public async Task<List<Product>> GetAllProductReviews()
        {
            return await productService.GetAllProductReviewsAsync();
        }
    }
}

