using Microsoft.AspNetCore.Mvc;
using SecureStoreMVC.Models;
using System.Diagnostics;

namespace SecureStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return Login();
        }
        public IActionResult Login()
        {
            return RedirectToAction("LoginView", "User");
        }
    }
}
