using MGM.Pbgov.AppServices.Converters;
using MGM.Pbgov.AppServices.Response;
using MGM.Pbgov.Core.Handler.Search;
using MGM.Pbgov.Core.Query;
using MGM.Pbgov.Core.ValueObjects;

namespace MGM.Pbgov.AppServices.Services.Search
{
    internal class FamilyQueryAppService(
        IQueryHandler<IFamilyListAllQuery, List<FamilyVO>> queryListAllHandler,
        IQueryHandler<IFamilyGetByIdQuery, FamilyVO> queryGetByIdHandler,
        IFamilyListAllQuery familyListAllQuery,
        IFamilyGetByIdQuery familyGetByIdQuery) : IFamilyQueryAppService
    {
        private readonly IQueryHandler<IFamilyListAllQuery, List<FamilyVO>> _queryListAllHandler = queryListAllHandler;
        private readonly IQueryHandler<IFamilyGetByIdQuery, FamilyVO> _queryGetByIdHandler = queryGetByIdHandler;
        private readonly IFamilyListAllQuery _familyListAllQuery = familyListAllQuery;
        private readonly IFamilyGetByIdQuery _familyGetByIdQuery = familyGetByIdQuery;


        public async Task<GetFamilyResponse?> GetByIdAsync(string id)
        {
            _familyGetByIdQuery.AddId(id);
            var ret = await _queryGetByIdHandler.Handle(_familyGetByIdQuery);

            return ret is null ? default :
                ret.ToViewModel();
        }

        public async Task<IEnumerable<GetFamilyResponse?>?> ListAllAsync()
        {
            var ret = await _queryListAllHandler.Handle(_familyListAllQuery);

            return ret is null ? default :
                ret.Select(c => c.ToViewModel());
        }
    }
}
