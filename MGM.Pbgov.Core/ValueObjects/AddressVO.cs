namespace MGM.Pbgov.Core.ValueObjects
{
    public class AddressVO
    {
        public string Street { get; set; } = string.Empty;

        public int? Number { get; set; }

        public string County { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
    }
}
