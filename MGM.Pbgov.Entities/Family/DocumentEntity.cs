namespace MGM.Pbgov.Entities.Family
{
    public class DocumentEntity
    {
        public string Value { get; private set; } = string.Empty;

        public EDocumentType Type { get; private set; }

        public void AddValue(string value) => Value = value;

        public void AddType(EDocumentType value) => Type = value;
    }
}
