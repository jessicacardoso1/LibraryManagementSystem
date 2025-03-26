using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastrusture(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddRepositories()
                 .AddData(configuration);
            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LibraryCs");

            services.AddDbContext<LibraryManagementSystemDbContext>(o => o.UseSqlServer(connectionString));

            return services;

        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
