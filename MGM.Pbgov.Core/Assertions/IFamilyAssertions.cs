using MGM.Pbgov.Core.ValueObjects;
using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Assertions
{
    public interface IFamilyAssertions
    {
        void FamilyNeedsToBeValid(FamilyEntity? valueObject, string id);
    }
}
