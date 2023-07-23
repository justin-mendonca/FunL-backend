using FunL_backend.Dtos.NewFolder;
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
            return Ok(await _userService.RegisterUser(userData));
        }
    }
}
