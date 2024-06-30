using MGM.Pbgov.AppServices.Response;
using MGM.Pbgov.AppServices.Services.Search;
using MGM.Pbgov.Infrastructure.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MGM.Pbgov.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Gestão de cadastro de famílias para beneficio governamental")]
    public class PopularRegistrationController(IFamilyQueryAppService queryAppService) : ControllerBase
    {
        private readonly IFamilyQueryAppService _queryAppService = queryAppService;

        [HttpGet(Name = "ListAll")]
        [SwaggerOperation(Summary = "Lista de cavaleiros cadastrados")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<GetFamilyResponse>))]
        public async Task<IActionResult> ListAllAsync()
            => Ok(await _queryAppService.ListAllAsync());

        [HttpGet("{id}", Name = "GetById")]
        [SwaggerOperation(Summary = "Busca de cavaleiro por identificador")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetFamilyResponse))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetByLicensePlateAsync([FromRoute(Name = "id")][Required] string id)
            => Ok(await _queryAppService.GetByIdAsync(id));
    }
}
