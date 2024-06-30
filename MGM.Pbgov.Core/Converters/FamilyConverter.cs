using MGM.Pbgov.Core.ValueObjects;
using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Converters
{
    public static class FamilyConverter
    {
        public static FamilyVO ToValueObject(this FamilyEntity entity, int points) =>
            new()
            {
                Id = entity.Id,
                MonthlyIncome = entity.MonthlyIncome,
                Persons = entity.Persons.Select(c => new PersonVO { 
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Age = c.Age,
                    BirthDate = c.BirthDate,
                    IsDependency = c.IsDependency,
                    Documents = c.Documents.Select(x => new DocumentVO {
                        Type = x.Type,
                        Value = x.Value
                    })
                }),
                Address = new AddressVO { 
                    County = entity.Address.County,
                    Number = entity.Address.Number,
                    State = entity.Address.State,
                    Street = entity.Address.Street,
                    ZipCode = entity.Address.ZipCode
                },
                Points = points
            };
    }
}
