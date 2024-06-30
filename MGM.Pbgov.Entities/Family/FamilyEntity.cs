using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MGM.Pbgov.Entities.Family
{
    public class FamilyEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; } = string.Empty;

        public decimal MonthlyIncome { get; private set; }

        public AddressEntity Address { get; private set; } = null!;

        public IList<PersonEntity> Persons { get; private set; } = null!;

        public void AddId(string value) => Id = value;

        public void AddMonthlyIncome(decimal value) => MonthlyIncome = value;

        public void AddAddress(AddressEntity value) => Address = value;

        public void AddPerson(PersonEntity value) => Persons.Add(value);
    }
}
