using Microsoft.AspNetCore.Mvc;
using SMSolution.Domain.Application.Services.AuthService;
using SMSolution.Domain.Application.Services.UserService;
using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.Session;
using System.Threading.Tasks;

namespace SMSolution.API.Controllers.SessionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("session")]
        public async Task<IActionResult> Authenticate([FromBody] SessionVM vm)
        {

            User user = await _userService.Login(vm.Email, vm.Password);

            if (user is null)
                return NotFound(new { message = "Usuário não encontrado" });

            string token = await _tokenService.GenerateToken(user);

            return Ok( new { token });
        }

    }
}
