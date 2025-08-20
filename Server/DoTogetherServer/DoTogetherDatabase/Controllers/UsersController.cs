using DoTogetherDatabase.Common.DTOs;
using DoTogetherDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DoTogetherDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Register(UserRegisterDto dto)
        {
            if (User.Identity?.IsAuthenticated ?? false)
                return BadRequest("Already logged in.");
            var result = await _service.RegisterAsync(dto);
            if (result == null) return BadRequest("Email already exists.");
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Login(UserLoginDto dto)
        {
            if (User.Identity?.IsAuthenticated ?? false)
                return BadRequest("Already logged in.");
            var result = await _service.LoginAsync(dto);
            if (result == null) return Unauthorized();
            return Ok(result);
        }
    }
}