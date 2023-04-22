using IdentityMicroservice.Business;
using IdentityMicroservice.Business.Contracts;
using IdentityMicroservice.Repository;
using IdentityMicroservice.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityMicroservice.DI
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBusinessLogic, UserBusinessLogic>();
            return services;
        }
    }
}