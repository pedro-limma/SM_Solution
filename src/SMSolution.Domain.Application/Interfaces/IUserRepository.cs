using SMSolution.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Interfaces
{
    public interface IUserRepository
    {

        Task<User> Create(User usr);
        Task<IList<User>> Index();
        Task<User> IndexByCPF(string cpf);
        Task<User> UpdateByCPF(string cpf, User usr);
        Task<string> DeleteUser(string cpf);
        Task<User> LoginUser(string email, string password);

    }
}
