using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Auth;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SendGrid;
using LibraryManagementSystem.Infrastructure.Notifications;
using SendGrid.Extensions.DependencyInjection;


namespace LibraryManagementSystem.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastrusture(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddRepositories()
                 .AddData(configuration)
                 .AddAuth(configuration)
                 .AddEmailService(configuration);
            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LibraryCs");

            services.AddDbContext<LibraryManagementSystemDbContext>(o => o.UseSqlServer(connectionString,
            b => b.MigrationsAssembly(typeof(LibraryManagementSystemDbContext).Assembly.FullName)));
            return services;

        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookLoanRepository, BookLoanRepository>();
            services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
            return services;
        }

        private static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSendGrid(o =>
            {
                o.ApiKey = configuration.GetValue<string>("SendGrid:ApiKey");
            });

            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
