using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaFast.Application.Interfaces;
using PizzaFast.Application.Mappings;
using PizzaFast.Application.Services;
using PizzaFast.Domain.Interfaces;
using PizzaFast.Infra.Context;
using PizzaFast.Infra.Repositories;
using System;

namespace PizzaFast.Shared.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
