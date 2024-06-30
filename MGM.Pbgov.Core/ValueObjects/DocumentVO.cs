using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.ValueObjects
{
    public class DocumentVO
    {
        public string Value { get; set; } = string.Empty;

        public EDocumentType Type { get; set; }
    }
}
