using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Repository
{
    public interface IPopularRegistrationRepository
    {
        Task<FamilyEntity> GetFamilyByIdAsync(string id);

        Task<IEnumerable<FamilyEntity>> ListAllFamilyAsync();
    }
}
