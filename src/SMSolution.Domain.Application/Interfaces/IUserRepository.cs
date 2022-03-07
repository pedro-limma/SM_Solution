using SMSolution.Domain.Core.Models;

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

        dynamic Create(User usr);
        dynamic Index();
        dynamic IndexByCPF(User usr);
        dynamic Update(User usr);
        dynamic Delete(User usr);

    }
}
