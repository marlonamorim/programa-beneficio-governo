﻿using System.Net;

namespace MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions
{
    public class HttpClientRequestException(string message, HttpStatusCode statusCode) : Exception
    {
        public override string Message { get; } = message;
        public HttpStatusCode StatusCode { get; set; } = statusCode;
    }
}
