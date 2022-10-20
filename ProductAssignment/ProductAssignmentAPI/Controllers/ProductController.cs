using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAssignmentBAL.Services;
using ProductAssignmentEntity.Models;
using System.Collections.Generic;

namespace ProductAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Ok("Product created successfully!!");
        }

        [HttpGet("GetProductById")]
        public Product GetProductById(int productId)
        {
            return _productService.GetProductById(productId);
        }


    }
}
