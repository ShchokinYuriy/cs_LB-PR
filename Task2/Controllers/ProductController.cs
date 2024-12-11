using Microsoft.AspNetCore.Mvc;
using Task2.Models;
using Task2.Services;
using Microsoft.AspNetCore.Authorization;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase // Додано "ControllerBase"
    {
        private readonly IProductService _productService;

        // Інжекція сервісу через конструктор
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest();
            }

            var createdProduct = _productService.CreateProduct(newProduct);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var product = _productService.UpdateProduct(id, updatedProduct);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var success = _productService.DeleteProduct(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
