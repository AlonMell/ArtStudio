using System.Net;

namespace ArtStudio.Core.Errors;

public class ServiceException(HttpStatusCode statusCode, string? message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;

    public static ServiceException NotFound(string message) => 
        new ServiceException(HttpStatusCode.NotFound, message);

    public static ServiceException BadRequest(string message) => 
        new ServiceException(HttpStatusCode.BadRequest, message);
}