using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaFast.Infra.Context;

namespace PizzaFast.Shared.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            return services;
        }
    }
}
