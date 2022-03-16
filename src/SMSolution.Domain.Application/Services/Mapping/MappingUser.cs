using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
using SMSolution.Domain.Core.ViewModels.Output;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SMSolution.Domain.Application.Services.Mapping
{
    public class MappingUser : IMappingUser
    {
        public User MappingToInUser(UpdateUserVM vm)
        {
            return new User
            {
                Name = vm.Name,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Role = vm.Role,
                UpdatedAt = vm.UpdatedAt,
            };
        }

        public User MappingToInUser(CreateUserVM vm)
        {
            return new User
            {
                Name = vm.Name,
                CPF = vm.CPF,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Role = vm.Role,
                Password = new Crypt(SHA512.Create()).HashPassword(vm.Password),
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };
        }

        public UserResponse MappingToOutUser(User vm)
        {
            return new UserResponse
            {
                Name= vm.Name,
                Email= vm.Email,
                PhoneNumber= vm.PhoneNumber,
                CPF= vm.CPF,
                Role= vm.Role
            };
        }

        public IList<UserResponse> MappingToOut(IList<User> users)
        {
            IList<UserResponse> result = new List<UserResponse>();

            foreach (User user in users)
            {
                result.Add(new UserResponse
                {
                    Name = user.Name,
                    Role = user.Role,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    CPF = user.CPF,
                });
            }

            return result;
        }
    }
}
