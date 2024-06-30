using System.Net;

namespace MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientBadRequestException(string message) : HttpClientRequestException(message, HttpStatusCode.BadRequest)
    {
    }
}
