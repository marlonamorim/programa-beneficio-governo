namespace MGM.Pbgov.Core.ValueObjects
{
    public class PersonVO
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsDependency { get; set; }

        public IEnumerable<DocumentVO> Documents { get; set; } = [];

    }
}
