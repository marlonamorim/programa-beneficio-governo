using MGM.Pbgov.Entities.Family;
using MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions;
using System.Net;

namespace MGM.Pbgov.Core.Assertions
{
    public class FamilyAssertions(IDefaultHttpClientErrorResponseHandler defaultHttpClientErrorResponseHandler) : IFamilyAssertions
    {
        private readonly IDefaultHttpClientErrorResponseHandler _defaultHttpClientErrorResponseHandler = defaultHttpClientErrorResponseHandler;

        public void FamilyNeedsToBeValid(FamilyEntity? valueObject, string id)
        {
            if (valueObject is null)
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.NotFound,
                    string.Empty,
                    $"Não foi encontrada família cadastrada para o id {id} informado.");
        }
    }
}
