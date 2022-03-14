using SMSolution.Domain.Core.Models;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Interfaces
{
    public interface IUserRepository
    {

        Task<dynamic> Create(User usr);
        Task<dynamic> Index();
        Task<dynamic> IndexByCPF(string cpf);
        Task<dynamic> UpdateByCPF(string cpf, User usr);
        Task<dynamic> DeleteUser(string cpf);
        Task<User> LoginUser(string email, string password);

    }
}
