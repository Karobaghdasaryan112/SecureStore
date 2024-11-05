using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SecureStore.API.DTOs.UserDTOs;
using SecureStore.API.Services.Interfaces;

namespace SecureStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLogin)
        {
            try
            {
                var UserProfileModel = await _userService.UserLogin(userLogin);

                return Ok(UserProfileModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationModel userRegistration)
        { 
            try
            {
                await _userService.UserRegistration(userRegistration);
                return Ok(userRegistration);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
