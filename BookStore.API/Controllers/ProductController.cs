using Microsoft.AspNetCore.Mvc;
using BookStore_project.Core.Models;
using BookStore_project.Core.IServices;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(decimal id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);
        }

        // GET: api/product/category/2
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetAllProductsByCategory(decimal categoryId)
        {
            var products = await _productService.GetAllProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        // GET: api/product/author/3
        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetProductsByAuthor(decimal authorId)
        {
            var products = await _productService.GetProductsByAuthorAsync(authorId);
            return Ok(products);
        }

        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProductAsync(product);
            return Ok(new { message = "Product created successfully" });
        }

        // PUT: api/product
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            await _productService.UpdateProductAsync(product);
            return Ok(new { message = "Product updated successfully" });
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(decimal id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}