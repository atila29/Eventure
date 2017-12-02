namespace Eventure.Query.QueryHandler
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get(TQuery query);
    }
}