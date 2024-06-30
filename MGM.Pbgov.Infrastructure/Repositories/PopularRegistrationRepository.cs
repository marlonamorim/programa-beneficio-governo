using MGM.Pbgov.Entities.Family;
using MGM.Pbgov.Infrastructure.DataSettings;
using MGM.Pbgov.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MGM.Pbgov.Infrastructure.Repositories
{
    internal class PopularRegistrationRepository : IPopularRegistrationRepository
    {
        private readonly IMongoCollection<FamilyEntity> _familyCollection;

        public PopularRegistrationRepository(IOptions<PopularRegistrationStoreDatabaseSettings> popularRegistrationStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            popularRegistrationStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                popularRegistrationStoreDatabaseSettings.Value.DatabaseName);

            _familyCollection = mongoDatabase.GetCollection<FamilyEntity>(
                popularRegistrationStoreDatabaseSettings.Value.FamilyCollectionName);
        }

        public async Task<FamilyEntity> GetFamilyByIdAsync(string id)
            => await _familyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<FamilyEntity>> ListAllFamilyAsync()
            => await _familyCollection.Find(_ => true).ToListAsync();
    }
}
