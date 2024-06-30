using MGM.Pbgov.Entities.Score;

namespace MGM.Pbgov.Repository
{
    public interface IPointRangeRepository
    {
        Task<IEnumerable<PointRangeEntity>> ListAllAsync();
    }
}
