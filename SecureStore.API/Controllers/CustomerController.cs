using Microsoft.AspNetCore.Mvc;
using SecureStore.API.Domain.Entities;
using SecureStore.API.Services.Interfaces;

namespace SecureStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService { get; set; }
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("Orders/{customerId}")]
        public IActionResult GetShoppingCart(Guid customerId)
        {
            ICollection<Order> Orders = _customerService.GetOrdersByCustomer(customerId);
            return Ok(Orders);
        }
    }
}
