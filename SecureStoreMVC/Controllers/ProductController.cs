using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SecureStore.MVC.Services;

namespace SecureStore.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ApiService _apiService { get; set; }
        public ProductController(ApiService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        [Route("ProductsView")]
        public async Task<IActionResult> ProductsView()
        {
            var Products = await _apiService.GetAllProducts();
            ViewData["Products"] = Products;
            return View("Product", Products);
        }
    }
}
