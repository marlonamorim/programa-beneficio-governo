using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MGM.Pbgov.Entities.Score
{
    public class PointRangeEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public decimal From { get; set; }

        public decimal To { get; set; }

        public int Points { get; set; }
    }
}
