using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSolution.Adapters.MongoDB.Repository;
using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Application.Services.AuthService;
using SMSolution.Domain.Application.Services.Mapping;
using SMSolution.Domain.Application.Services.UserService;

namespace SMSolution.Adapters.IOC.DomainNativeInjector
{
    public static class DomainInjectorExtensions
    {

        public static IServiceCollection RegisterDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            //UseCases
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMappingUser, MappingUser>();

            //repo    
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
