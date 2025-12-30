using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_CRUD_App.JWT_Token;

namespace Student_CRUD_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            
            if (username == "admin" && password == "123")
            {
                var token = _tokenService.GenerateToken(username);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
