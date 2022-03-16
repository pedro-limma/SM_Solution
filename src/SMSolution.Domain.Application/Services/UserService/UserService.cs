using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Application.Services.Mapping;
using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMappingUser _mapping;
        public UserService(IUserRepository repo, IMappingUser mapping)
        {
            _repo = repo;
            _mapping = mapping;
        }

        public async Task<dynamic> CreateUser(CreateUserVM vm)
        {
            User obj = _mapping.MappingToInUser(vm);


            return await _repo.Create(obj);
        }


        public async Task<dynamic> IndexUsers()
        {
            return await _repo.Index();
        }

        public async Task<dynamic> FindUserByCPF(string cpf)
        {
            return await _repo.IndexByCPF(cpf);
        }

        public async Task<dynamic> UpdateUserByCPF(string cpf, UpdateUserVM usr)
        {
            User obj = new()
            {
                Name = usr.Name,
                Email = usr.Email,
                Role = usr.Role,
                UpdatedAt = usr.UpdatedAt,
                PhoneNumber = usr.PhoneNumber,
            };

            return await _repo.UpdateByCPF(cpf, obj);
        }

        public async Task<dynamic> DeleteUser(string cpf)
        {
            return await _repo.DeleteUser(cpf);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _repo.LoginUser(email, password);
        }
    }
}
