using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Dogs;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IBirdRepository, BirdRepository>();

            return services;
        }
    }
}
