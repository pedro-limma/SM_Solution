using SMSolution.Domain.Core.ViewModels.Input.User;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.UserService
{
    public interface IUserService
    {
        Task<dynamic> CreateUser(CreateUserVM vm);

        Task<dynamic> IndexUsers();

        Task<dynamic> FindUserByCPF(int cpf);
    }
}