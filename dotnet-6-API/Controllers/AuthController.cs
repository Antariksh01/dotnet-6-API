using dotnet_6_API.DTO.User;
using dotnet_6_API.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_6_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUserDTO request) {

            var response = await _authRepository.RegisterUser(
                new User() { Username = request.UserName }, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginUserDTO request)
        {

            var response = await _authRepository.Login(
                request.UserName, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
