using Chat.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Chat.WebApp.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddIdentity();

            services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,options =>
            {
                options.Cookie.Name = "chatAuth";
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.ExpireTimeSpan= TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });
            return services;
        }

        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ChatContext>()
              .AddDefaultTokenProviders();

            return services;
        }
    }
}
