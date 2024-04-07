using ArtStudio.Core.Services;

namespace ArtStudio.Core.Extensions;

public static class ArtServiceExtension
{
    public static void UseArtService(this IServiceCollection services)
    {
        services.AddScoped<IArtService, ArtService>();
    }
}