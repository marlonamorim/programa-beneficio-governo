using System.Net;

namespace MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientResourceNotFoundException(string message) : HttpClientRequestException(message, HttpStatusCode.NotFound)
    {
    }
}
