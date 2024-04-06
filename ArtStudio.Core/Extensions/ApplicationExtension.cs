using ArtStudio.Core.Errors;

namespace ArtStudio.Core.Extensions;

public static class ApplicationExtension
{
    public static WebApplication UseAppConfiguration(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        //app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Art}/{action=GetArts}/{id?}");
        
        return app;
    }
}