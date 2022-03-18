using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
using SMSolution.Domain.Core.ViewModels.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserResponse> CreateUser(CreateUserVM vm);
        Task<IList<UserResponse>> IndexUsers();
        Task<UserResponse> FindUserByCPF(string cpf);
        Task<string> DeleteUser(string cpf);
        Task<UserResponse> UpdateUserByCPF(string cpf, UpdateUserVM vm);
        Task<UserResponse> Login(string email, string password);
    }
}