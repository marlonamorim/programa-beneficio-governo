namespace MGM.Pbgov.Entities.Family
{
    public class PersonEntity
    {
        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public int Age { get 
            { 
                return DateTime.Now.Year - BirthDate.Year; 
            }
        }

        public DateTime BirthDate { get; private set; }

        public bool IsDependency { get; private set; }

        public IList<DocumentEntity> Documents { get; private set; } = [];

        public void AddFirstName(string value) => FirstName = value;

        public void AddLastName(string value) => LastName = value;

        public void AddBirthDate(DateTime value) => BirthDate = value;

        public void AddIsDependency(bool value) => IsDependency = value;

        public void AddDocument(DocumentEntity value) => Documents.Add(value);

    }
}
