using SMSolution.Domain.Core.ViewModels.Input.User;

namespace SMSolution.Domain.Application.Services.UserService
{
    public interface IUserService
    {
        dynamic CreateUser(CreateUserVM vm);
    }
}