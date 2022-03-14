using Microsoft.AspNetCore.Mvc;
using SMSolution.Domain.Application.Services.UserService;
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
        public async Task<IActionResult> IndexUserByCPF(string cpf)
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

        [HttpPut("edit/")]
        public async Task<IActionResult> UpdateUser(
            [FromQuery] string cpf,
            [FromBody] UpdateUserVM vm)
        {
            try
            {
                return Ok(await _usrService.UpdateUserByCPF(cpf, vm));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/")]
        public async Task<IActionResult> DeleteUser([FromQuery] string cpf)
        {
            try
            {
                return Ok(await _usrService.DeleteUser(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

