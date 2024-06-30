namespace MGM.Pbgov.Core.Query
{
    public interface ISearchQuery<TOut> : IQuery
        where TOut : new()
    {
        Task<TOut?> ExecuteAsync();
    }

    public interface IQuery
    {
    }
}
