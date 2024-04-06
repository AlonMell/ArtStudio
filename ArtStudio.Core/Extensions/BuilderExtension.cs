using ArtStudio.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtStudio.Core.Extensions;

public static class BuilderExtension
{
    public static WebApplicationBuilder UseBuilderConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllersWithViews();
        builder.Services.AddArtService();
        builder.Services.AddDbContext<ArtStudioDbContext>(options => 
                options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ArtStudioDbContext))));
        return builder;
    }
}