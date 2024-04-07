using ArtStudio.Core.Infrastructure;
using ArtStudio.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace ArtStudio.Core.Extensions;

public static class UserExtension
{
    public static void UseUserAuthentication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();
    }
}