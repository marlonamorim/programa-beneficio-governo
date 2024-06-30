namespace MGM.Pbgov.Infrastructure.DataSettings
{
    public class PopularRegistrationStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string FamilyCollectionName { get; set; } = null!;

        public string PointRangeCollectionName { get; set; } = null!;

        public string DependentRangeCollectionName { get; set; } = null!;
    }
}
