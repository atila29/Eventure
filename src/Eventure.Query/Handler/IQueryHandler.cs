namespace Eventure.Query.Handler
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get(TQuery query);
    }
}