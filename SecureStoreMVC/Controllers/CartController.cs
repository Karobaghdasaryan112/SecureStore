using Microsoft.AspNetCore.Mvc;
using SecureStore.API.Domain.Entities;
using SecureStore.MVC.Services;
using SecureStore.MVC.UserDTOs;

namespace SecureStore.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private ApiService _apiService;
        public CartController(ApiService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        [Route("OrdersView")]
        public async Task<IActionResult> OrdersView()
        {
            string UserName = TempData["UserName"] as string;
            var Orders = await _apiService.GetOrderByUser(UserName);

            if (Orders == null)
            {
                return NotFound("Заказы не найдены для данного пользователя.");
            }

            var ordersModel = Orders.Select(order => new OrderModel
            {
                CustomerName = order.CustomerName,
                InvoiceNumber = order.InvoiceNumber,
                Address = order.Address,
                LineItems = order.LineItems,
                DatePlaced = order.DatePlaced,
                DateFilled = order.DateFilled,
                Status = (UserDTOs.OrderStatus)order.Status,
                PaymentStatus = (UserDTOs.PaymentStatus)order.PaymentStatus,
                Term = (UserDTOs.Term)order.Term
            }).ToList();

            return View("ShoppingCart", ordersModel);
        }

    }
}
