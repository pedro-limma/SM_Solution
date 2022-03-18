using SMSolution.Domain.Core.Models;
using SMSolution.Domain.Core.ViewModels.Input.User;
using SMSolution.Domain.Core.ViewModels.Output;
using System.Collections.Generic;

namespace SMSolution.Domain.Application.Services.Mapping
{
    public interface IMappingUser
    {
        User MappingToInUser(UpdateUserVM vm);
        User MappingToInUser(CreateUserVM vm);
        UserResponse MappingToOut(User vm);
        IList<UserResponse> MappingToOut(IList<User> users);
    }
}