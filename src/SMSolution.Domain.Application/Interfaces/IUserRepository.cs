using SMSolution.Domain.Core.Models;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Interfaces
{
    public interface IUserRepository
    {
        /*
         Create
         Index
         IndexByCPF
         Update
         Delete
        */

        Task<dynamic> Create(User usr);
        Task<dynamic> Index();
        Task<dynamic> IndexByCPF(int cpf);
        //dynamic Update(User usr);
        //dynamic Delete(User usr);

    }
}
