using MGM.Pbgov.AppServices.Response;
using MGM.Pbgov.Core.ValueObjects;

namespace MGM.Pbgov.AppServices.Converters
{
    public static class FamilyConverter
    {
        public static GetFamilyResponse ToViewModel(this FamilyVO familyVaueObject) =>
            new()
            {
                Id = familyVaueObject.Id,
                MonthlyIncome = familyVaueObject.MonthlyIncome,
                Address = new AddressResponse {
                    County = familyVaueObject.Address.County,
                    Number = familyVaueObject.Address.Number,
                    State = familyVaueObject.Address.State,
                    Street = familyVaueObject.Address.Street,
                    ZipCode = familyVaueObject.Address.ZipCode
                },
                Persons = familyVaueObject.Persons.Select(c => new PersonResponse { 
                    Age = c.Age,
                    BirthDate = c.BirthDate,
                    IsDependency = c.IsDependency,
                    Name = $"{c.FirstName} {c.LastName}",
                    Documents = c.Documents.Select(x => new DocumentResponse { 
                        Type = x.Type,
                        Value = x.Value
                    })
                }),
                Points = familyVaueObject.Points
            };
    }
}
