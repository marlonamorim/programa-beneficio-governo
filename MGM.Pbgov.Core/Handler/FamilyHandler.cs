using MGM.Pbgov.Core.Handler.Search;
using MGM.Pbgov.Core.Query;
using MGM.Pbgov.Core.ValueObjects;

namespace MGM.Pbgov.Core.Handler
{
    public class FamilyHandler() : 
        IQueryHandler<IFamilyListAllQuery, List<FamilyVO>>,
        IQueryHandler<IFamilyGetByIdQuery, FamilyVO>
    {
        public async Task<List<FamilyVO>?> Handle(IFamilyListAllQuery query)
            => await query.ExecuteAsync();

        public async Task<FamilyVO?> Handle(IFamilyGetByIdQuery query)
            => await query.ExecuteAsync();
    }
}
