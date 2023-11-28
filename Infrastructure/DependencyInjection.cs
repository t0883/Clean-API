using Infrastructure.Authentication;
using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddSingleton<JwtTokenGenerator>();
            return services;
        }
    }
}
