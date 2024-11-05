using Microsoft.AspNetCore.Mvc;
using SecureStore.API.Domain.Entities;
using SecureStore.API.DTOs.UserDTOs;
using SecureStore.MVC.Services;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private ApiService _service { get; set; }

    public UserController(ApiService service)
    {
        _service = service;
    }
    [HttpPost]
    [Route("UserLogin")]
    public async Task<IActionResult> UserLogin([FromForm] UserLoginModel userLogin)
    {
        var userProfile = await _service.UserLogin(userLogin);

        if (userProfile == null)
        {
            return Unauthorized();
        }
        TempData["UserName"] = userLogin.UserName;
        return RedirectToAction("Profile", new { firstName = userProfile.FirstName, lastName = userProfile.LastName, Email = userProfile.Email });
    }

    [HttpPost]
    [Route("UserRegistration")]
    public async Task<IActionResult> UserRegistration([FromForm] UserRegistrationModel userRegistration)
    {
        try
        {
            await _service.UserRegistration(userRegistration);
            return RedirectToAction("LoginView");
        }
        catch
        {
            return View("Registration");
        }
    }

    [HttpGet]
    [Route("RegistrationView")]
    public IActionResult RegistrationView()
    {
        return View("Registration");
    }

    [HttpGet]
    [Route("LoginView")]
    public IActionResult LoginView()
    {
        return View("Login");
    }

    [HttpGet]
    [Route("Profile")]
    public IActionResult Profile(string firstName, string lastName, string Email)
    {
        var userProfile = new UserProfileModel
        {
            FirstName = firstName,
            LastName = lastName,
            Email = Email,
        };
        ViewData["FirstName"] = firstName;
        ViewData["LastName"] = lastName;
        ViewData["Email"] = Email;
        return View("Profile", userProfile);
    }
}

