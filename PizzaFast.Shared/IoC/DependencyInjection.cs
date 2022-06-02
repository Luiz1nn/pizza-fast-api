using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaFast.Infra.Context;
using System;

namespace PizzaFast.Shared.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
            //    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("ConnectionString"), new MySqlServerVersion(new Version(8, 0, 11))));

            return services;
        }
    }
}
