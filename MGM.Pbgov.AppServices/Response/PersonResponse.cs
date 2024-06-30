namespace MGM.Pbgov.Core.ValueObjects
{
    public class PersonResponse
    {
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsDependency { get; set; }

        public IEnumerable<DocumentResponse> Documents { get; set; } = [];

    }
}
