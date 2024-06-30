using MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions;
using Moq;
using System.Net;

namespace MGM.Pbgov.Core.UnitTests.Assertions
{
    public class FamilyAssertions
    {
        private const string FAMILY_IS_NOT_VALID_EXCEPTION_NOTFOUND_MESSAGE = "Não foi encontrada família cadastrada para o id {0} informado.";
        private readonly Mock<IDefaultHttpClientErrorResponseHandler> _defaultHttpClientErrorResponseHandler;
        private readonly Core.Assertions.IFamilyAssertions _familyAssertions;

        public FamilyAssertions()
        {
            _defaultHttpClientErrorResponseHandler = new Mock<IDefaultHttpClientErrorResponseHandler>();
            _familyAssertions = new Core.Assertions.FamilyAssertions(_defaultHttpClientErrorResponseHandler.Object);
        }

        [Theory(DisplayName = "Shold_Generate_NotFoundException_When_Family_Is_Not_Exists")]
        [InlineData("662f0b0fcf7510100bbe4b65")]
        public void FamilyNeedsToBeValid_SholdReturnNotFoundException(string familyId)
        {
            _defaultHttpClientErrorResponseHandler.Setup(c => c.ThrowResponseError(HttpStatusCode.NotFound, string.Empty, string.Format(FAMILY_IS_NOT_VALID_EXCEPTION_NOTFOUND_MESSAGE, familyId)))
                .Returns(new HttpClientBadRequestException(string.Format(FAMILY_IS_NOT_VALID_EXCEPTION_NOTFOUND_MESSAGE, familyId)));

            HttpClientBadRequestException exception = Assert.Throws<HttpClientBadRequestException>(() => _familyAssertions.FamilyNeedsToBeValid(null, familyId));
            Assert.Equal(string.Format(FAMILY_IS_NOT_VALID_EXCEPTION_NOTFOUND_MESSAGE, familyId), exception.Message);
        }
    }
}
