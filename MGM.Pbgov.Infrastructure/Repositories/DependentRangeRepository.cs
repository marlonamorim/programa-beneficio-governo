using MGM.Pbgov.Entities.DependentRange;
using MGM.Pbgov.Infrastructure.DataSettings;
using MGM.Pbgov.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Pbgov.Infrastructure.Repositories
{
    internal class DependentRangeRepository : IDependentRangeRepository
    {
        private readonly IMongoCollection<DependentRangeEntity> _pointRangeCollection;

        public DependentRangeRepository(IOptions<PopularRegistrationStoreDatabaseSettings> popularRegistrationStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            popularRegistrationStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                popularRegistrationStoreDatabaseSettings.Value.DatabaseName);

            _pointRangeCollection = mongoDatabase.GetCollection<DependentRangeEntity>(
                popularRegistrationStoreDatabaseSettings.Value.DependentRangeCollectionName);
        }

        public async Task<IEnumerable<DependentRangeEntity>> ListAllAsync()
            => await _pointRangeCollection.Find(_ => true).ToListAsync();
    }
}
