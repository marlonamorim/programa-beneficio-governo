using System.Net;

namespace MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientUnauthorizedException(string message) : HttpClientRequestException(message, HttpStatusCode.Unauthorized)
    {
    }
}
