using FunL_backend.Dtos.User;
using FunL_backend.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace FunL_backend.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<string>>> RegisterUser(RegisterUserDto userData)
        {
            var serviceResponse = await _userService.RegisterUser(userData);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> LoginUser(LoginUserDto userData)
        {
            var serviceResponse = await _userService.LoginUser(userData);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse.Message);
            }

            return Ok(serviceResponse);
        }
    }
}
