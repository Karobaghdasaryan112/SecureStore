using Microsoft.AspNetCore.Mvc;
using SecureStore.API.Domain.Entities;
using SecureStore.API.Services.Interfaces;
namespace SecureStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService { get; set; }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("Products")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }
    }
}
