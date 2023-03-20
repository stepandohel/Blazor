using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.DI
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)
            ));

            return services;
        }
    }
}