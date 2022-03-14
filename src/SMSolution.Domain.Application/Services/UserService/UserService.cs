using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
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

        public async Task<dynamic> CreateUser(CreateUserVM vm)
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
            var obj = new User
            {
                Name=usr.Name,
                Email=usr.Email,
                Role=usr.Role,
                UpdatedAt=usr.UpdatedAt,
                PhoneNumber=usr.PhoneNumber,
                Password=usr.Password,
            };
            
            return _repo.UpdateByCPF(cpf, obj);
        }

        public async Task<dynamic> DeleteUser(string cpf)
        {
            return await _repo.DeleteUser(cpf);
        }
    }
}
