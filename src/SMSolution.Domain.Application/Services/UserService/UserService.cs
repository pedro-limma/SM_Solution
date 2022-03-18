using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Application.Services.Mapping;
using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
using SMSolution.Domain.Core.ViewModels.Output;
using System.Collections.Generic;
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

        public async Task<UserResponse> CreateUser(CreateUserVM vm)
        {
            User obj = _mapping.MappingToInUser(vm);

            return _mapping.MappingToOut(await _repo.Create(obj));
        }

        public async Task<IList<UserResponse>> IndexUsers()
        {
            return _mapping.MappingToOut(await _repo.Index());
        }

        public async Task<UserResponse> FindUserByCPF(string cpf)
        {
            return _mapping.MappingToOut(await _repo.IndexByCPF(cpf));
        }

        public async Task<UserResponse> UpdateUserByCPF(string cpf, UpdateUserVM usr)
        {
            User obj = _mapping.MappingToInUser(usr);

            return _mapping.MappingToOut(await _repo.UpdateByCPF(cpf, obj));
        }

        public async Task<string> DeleteUser(string cpf)
        {
            return await _repo.DeleteUser(cpf);
        }

        public async Task<UserResponse> Login(string email, string password)
        {
            return _mapping.MappingToOut(await _repo.LoginUser(email, password));
        }
    }
}
