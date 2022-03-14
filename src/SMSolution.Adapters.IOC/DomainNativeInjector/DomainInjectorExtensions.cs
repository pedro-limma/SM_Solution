using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSolution.Adapters.MongoDB.Repository;
using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Application.Services.UserService;

namespace SMSolution.Adapters.IOC.DomainNativeInjector
{
    public static class DomainInjectorExtensions
    {

        public static IServiceCollection RegisterDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            //UseCases
            services.AddScoped<IUserService, UserService>();

            //repo    
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
