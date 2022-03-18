using SMSolution.Domain.Core.ViewModels.Output;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.AuthService
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserResponse usr);
    }
}