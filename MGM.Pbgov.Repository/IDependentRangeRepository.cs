using MGM.Pbgov.Entities.DependentRange;

namespace MGM.Pbgov.Repository
{
    public interface IDependentRangeRepository
    {
        Task<IEnumerable<DependentRangeEntity>> ListAllAsync();
    }
}
