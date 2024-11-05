using Microsoft.AspNetCore.Mvc;
using SecureStore.API.Services.Impelemntations;
using SecureStore.API.Services.Interfaces;

namespace SecureStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("Orders/{UserName}")]
        public IActionResult GetOrdersByUserName(string UserName)
        {

            var Orders = _orderService.GetOrdersByCustomer(UserName);
           return  Ok(Orders);
        }
    }
}
