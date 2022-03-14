using Microsoft.IdentityModel.Tokens;
using SMSolution.Domain.Core.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMSolution.Domain.Application.Services.AuthService
{
    public class TokenService : ITokenService
    {

        public async Task<string> GenerateToken(User usr)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            //Buscar do app settings
            var key = Encoding.ASCII.GetBytes("43e4dbf0-52ed-4203-895d-42b586496bd4");

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usr.Name),
                    new Claim(ClaimTypes.Role, usr.Role),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
