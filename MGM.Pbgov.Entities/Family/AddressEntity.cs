namespace MGM.Pbgov.Entities.Family
{
    public class AddressEntity
    {
        public string Street { get; private set; } = string.Empty;

        public int? Number { get; private set; }

        public string County { get; private set; } = string.Empty;

        public string State { get; private set; } = string.Empty;

        public string ZipCode { get; private set; } = string.Empty;

        public void AddStreet(string value) => Street = value;

        public void AddNumber(int value) => Number = value;

        public void AddCounty(string value) => County = value;

        public void AddState(string value) => State = value;

        public void AddZipCode(string value) => ZipCode = value;
    }
}
