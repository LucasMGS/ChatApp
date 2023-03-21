using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chat.Core;
using Chat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Chat.Infrastructure.Repositories;
using Chat.Application;
using Chat.Domain.Contracts;
using Chat.Application.Abstractions;

namespace Chat.Infrastructure
{
    public static class Injector
    {
        public static IServiceCollection InjectApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddMediator()
                .AddDbContext(configuration)
                .AddRepositories()
                .AddScoped<ICurrentUser, CurrentUser>();
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ChatConnection") ?? throw new InvalidOperationException(
                    "Connection string 'ChatConnection' not found.");

            services.AddDbContext<ChatContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            return services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
            });
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
            return services;
        }
    }
}