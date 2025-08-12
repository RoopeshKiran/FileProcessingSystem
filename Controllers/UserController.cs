using FileProcessingSystem.Data.DTO;
using FileProcessingSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileProcessingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLoginServices _userService;
        public UserController(IUserLoginServices userService) => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userLoginDetailsDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userService.RegisterAsync(userLoginDetailsDTO);
                return Ok(new { success = true, message = "User registered" });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDetailsDTO userLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var valid = await _userService.ValidateCredentialsAsync(userLogin.Username,userLogin.Password);
            if (!valid) return Unauthorized(new { success = false, message = "Invalid credentials" });
           
            return Ok(new { success = true, message = "Login successful"});
        }
    }
}

