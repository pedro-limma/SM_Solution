using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSolution.Domain.Application.Services.UserService;
using SMSolution.Domain.Core.ViewModels.Input;
using SMSolution.Domain.Core.ViewModels.Input.User;
using System;

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
        public IActionResult CreateUser([FromBody] CreateUserVM vm)
        {
            try
            {
                return Ok(_usrService.CreateUser(vm));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("index")]
        public IActionResult IndexUsers()
        {
            return Ok();
        }

        [HttpGet("index/{cpf:int}")]
        public IActionResult IndexUsersByCPF()
        {
            return Ok();
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
