using MGM.Pbgov.Entities.Score;
using MGM.Pbgov.Infrastructure.DataSettings;
using MGM.Pbgov.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Pbgov.Infrastructure.Repositories
{
    internal class PointRangeRepository : IPointRangeRepository
    {
        private readonly IMongoCollection<PointRangeEntity> _pointRangeCollection;

        public PointRangeRepository(IOptions<PopularRegistrationStoreDatabaseSettings> popularRegistrationStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            popularRegistrationStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                popularRegistrationStoreDatabaseSettings.Value.DatabaseName);

            _pointRangeCollection = mongoDatabase.GetCollection<PointRangeEntity>(
                popularRegistrationStoreDatabaseSettings.Value.PointRangeCollectionName);
        }

        public async Task<IEnumerable<PointRangeEntity>> ListAllAsync()
            => await _pointRangeCollection.Find(_ => true).ToListAsync();
    }
}
