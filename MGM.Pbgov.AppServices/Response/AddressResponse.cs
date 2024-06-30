namespace MGM.Pbgov.AppServices.Response
{
    public class AddressResponse
    {
        public string Street { get; set; } = string.Empty;

        public int? Number { get; set; }

        public string County { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
    }
}
