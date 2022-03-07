using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSolution.Domain.Core.ViewModels.Input;
using SMSolution.Domain.Core.ViewModels.Input.User;

namespace SMSolution.API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserVM vm)
        {
            return Ok(vm);
        }

        [HttpGet("index")]
        public IActionResult IndexUsers()
        {
            return Ok();
        }

        [HttpGet("index/{cpf}")]
        public IActionResult IndexUsersByCPF()
        {
            return Ok();
        }

        [HttpPut("edit/{cpf}")]
        public IActionResult UpdateUser([FromBody] UpdateUserVM vm)
        {
            return Ok(vm);
        }

        [HttpDelete("delete/{cpf}")]
        public IActionResult DeleteUser([FromBody])
        {
            return Ok();
        }
    }
}
