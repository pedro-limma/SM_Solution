using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public dynamic CreateUser(CreateUserVM vm)
        {
            var obj = new User
            {
                Name = vm.Name,
                Email = vm.Email,
                CPF = vm.CPF,
                PhoneNumber = vm.PhoneNumber,
                Role = vm.Role,
                Password = vm.Password,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            return _repo.Create(obj);
        }
    }
}
