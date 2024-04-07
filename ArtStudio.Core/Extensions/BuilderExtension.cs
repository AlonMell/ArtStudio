using ArtStudio.Core.Context;
using ArtStudio.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ArtStudio.Core.Extensions;

public static class BuilderExtension
{
    public static WebApplicationBuilder UseBuilderConfiguration(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllersWithViews();
        services.UseArtService();
        services.UseUserAuthentication();
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        services.AddDbContext<ArtStudioDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString(nameof(ArtStudioDbContext))));
        
        return builder;
    }
}