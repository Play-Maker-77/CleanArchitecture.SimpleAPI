using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SCleanArchitecture.SimpleAPI.Domain.Repositories;
using SCleanArchitecture.SimpleAPI.Infrastructure.Data;
using SCleanArchitecture.SimpleAPI.Infrastructure.Repositories;

namespace SCleanArchitecture.SimpleAPI.Infrastructure.Extensions
{
    public static class InfrastructureConfigurations
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
