using SMSolution.Domain.Core.Models;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.AuthService
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User usr);
    }
}