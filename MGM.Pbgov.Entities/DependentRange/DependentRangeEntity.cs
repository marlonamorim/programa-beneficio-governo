using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MGM.Pbgov.Entities.DependentRange
{
    public class DependentRangeEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public int From { get; set; }

        public int To { get; set; }

        public int Points { get; set; }
    }
}
