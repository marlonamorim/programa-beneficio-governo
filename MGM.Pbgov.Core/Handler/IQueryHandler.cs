using MGM.Pbgov.Core.Query;

namespace MGM.Pbgov.Core.Handler.Search
{
    public interface IQueryHandler<TIn, TOut>
        where TIn : IQuery
        where TOut : new()
    {
        Task<TOut?> Handle(TIn query);
    }
}
