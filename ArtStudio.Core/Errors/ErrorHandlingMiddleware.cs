using System.Net;
using System.Text.Json;

namespace ArtStudio.Core.Errors;

public class ErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlingMiddleware> logger) 
{
    private static readonly Action<ILogger, string, Exception> LoggerMessage =
        Microsoft.Extensions.Logging.LoggerMessage.Define<string>(
            LogLevel.Error,
            eventId: new EventId(id: 0, name: "ERROR"),
            formatString: "{Message}"
        );
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        string? result;
        switch (exception)
        {
            case ServiceException serviceException:
                context.Response.StatusCode = (int)serviceException.StatusCode;
                result = serviceException.Message;
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                LoggerMessage(logger, "Unhandled Exception", exception);
                result = JsonSerializer.Serialize(/*new { errors = "Internal Server Error" }*/ exception.Message);
                break;
        }

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }
}