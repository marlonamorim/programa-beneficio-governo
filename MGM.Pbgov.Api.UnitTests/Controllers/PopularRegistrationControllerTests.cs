using MGM.Pbgov.Api.Controllers;
using MGM.Pbgov.AppServices.Response;
using MGM.Pbgov.AppServices.Services.Search;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace MGM.Pbgov.Api.UnitTests.Controllers
{
    public class PopularRegistrationControllerTests
    {
        private readonly Mock<IFamilyQueryAppService> _familyQueryAppService;
        private readonly PopularRegistrationController _popularRegistrationController;

        public PopularRegistrationControllerTests()
        {
            _familyQueryAppService = new Mock<IFamilyQueryAppService>();
            _popularRegistrationController = new PopularRegistrationController(_familyQueryAppService.Object);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnOkResult()
        {
            _familyQueryAppService.Setup(c => c.ListAllAsync())
                .ReturnsAsync([]);

            var result = await _popularRegistrationController.ListAllAsync();

            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)okResult.StatusCode!);
        }
    }
}
