using BET.Identity.Models.Register;
using Microsoft.AspNetCore.Mvc;
using BET.Identity.Models.Login;
using BET.Identity.Services;

namespace BET.IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _service;

        public AuthenticationController(IAuthenticateService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, [FromQuery] string role)
        {
            var result = await _service.RegisterUser(registerUser, role);
            if (result.StartsWith("User created successfully"))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var token = await _service.Login(loginModel);
            if (token != null)
            {
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
