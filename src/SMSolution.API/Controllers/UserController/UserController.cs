using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSolution.Domain.Application.Services.UserService;
using SMSolution.Domain.Core.ViewModels.Input;
using SMSolution.Domain.Core.ViewModels.Input.User;
using System;
using System.Threading.Tasks;

namespace SMSolution.API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _usrService;
        public UserController(IUserService usrService)
        {
            _usrService = usrService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserVM vm)
        {
            try
            {
                return Ok(await _usrService.CreateUser(vm));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("index")]
        public async Task<IActionResult> IndexUsers()
        {
            try
            {
                var result = await _usrService.IndexUsers();

                if (result is null)
                    return NotFound("Nenhum usuário foi encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("indexByCPF")]
        public async Task<IActionResult> IndexUserByCPF([FromQuery]int cpf)
        {
            try
            {
                var result = await _usrService.FindUserByCPF(cpf);

                if (result is null)
                    return NotFound("Nenhum usuário foi encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{cpf:int}")]
        public IActionResult UpdateUser([FromBody] UpdateUserVM vm)
        {
            return Ok(vm);
        }

        [HttpDelete("delete/{cpf:int}")]
        public IActionResult DeleteUser()
        {
            return Ok();
        }
    }
}
