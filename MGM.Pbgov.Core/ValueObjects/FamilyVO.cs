namespace MGM.Pbgov.Core.ValueObjects
{
    public class FamilyVO : ValueObject
    {
        public decimal MonthlyIncome { get; set; }

        public AddressVO Address { get; set; } = null!;

        public IEnumerable<PersonVO> Persons { get; set; } = null!;

        public int Points { get; set; }
    }
}