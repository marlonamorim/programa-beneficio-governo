using MGM.Pbgov.AppServices.Response;

namespace MGM.Pbgov.AppServices.Services.Search
{
    public interface IFamilyQueryAppService
    {
        Task<IEnumerable<GetFamilyResponse?>?> ListAllAsync();

        Task<GetFamilyResponse?> GetByIdAsync(string id);
    }
}
