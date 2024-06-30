using MGM.Pbgov.Core.ValueObjects;

namespace MGM.Pbgov.AppServices.Response
{
    public class GetFamilyResponse
    {
        public string? Id { get; set; }

        public decimal MonthlyIncome { get; set; }

        public AddressResponse Address { get; set; } = null!;

        public IEnumerable<PersonResponse> Persons { get; set; } = null!;

        public int Points { get; set; }
    }
}
