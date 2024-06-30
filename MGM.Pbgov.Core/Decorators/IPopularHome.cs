using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Decorators
{
    public interface IPopularHome
    {
        bool FamilyIsAuthorized(FamilyEntity familyEntity);

        Task<int> AppliedRuleAsync(FamilyEntity familyEntity);
    }
}
