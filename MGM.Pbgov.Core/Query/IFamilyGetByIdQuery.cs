using MGM.Pbgov.Core.ValueObjects;

namespace MGM.Pbgov.Core.Query
{
    public interface IFamilyGetByIdQuery : ISearchQuery<FamilyVO>
    {
        void AddId(string id);
    }
}
