using BookStore_project.Core.DTO;
using BookStore_project.Core.Models;
using BookStore_project.Core.Repository;
using BookStore_project.Core.Services;
using BookStore_project.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return productService.GetAllProducts();
        }

        [HttpGet]
        [Route("getByProductId/{id}")]
        public Product GetProductById(decimal id)
        {
            return productService.GetProductById(id);
        }

        [HttpPost]
        public void CreateProduct(Product product)
        {
            productService.CreateProduct(product);
        }

        [HttpPut]
        public void UpdateProduct(Product product)
        {
            productService.UpdateProduct(product);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteProduct(decimal id)
        {
            productService.DeleteProduct(id);
        }

        [HttpGet]
        [Route("GetAllProductsByCategory/{catId}")]
        public List<Product> GetAllProductsByCategory(decimal catId)
        {
            return productService.GetAllProductsByCategory(catId);
        }

        [HttpGet]
        [Route("GetProductsByAuthor/{authId}")]
        public List<Product> GetProductsByAuthor(decimal authId)
        {
            return productService.GetProductsByAuthor(authId);
        }

        [HttpPost]
        [Route("Search")]
        public List<Filter> Search(
        [FromBody] Filter search){

            return productService.Search(search);
        }

        // Multi-Mapping
        [HttpGet]
        [Route("GetAllProductReviews")]
        public async Task<List<Product>> GetAllProductReviews()
        {
            return await productService.GetAllProductReviewsAsync();
        }

    }
}