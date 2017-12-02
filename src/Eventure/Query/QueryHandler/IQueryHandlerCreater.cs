namespace Eventure.Query.QueryHandler
{
    public interface IQueryHandlerCreater<out TResponse,in TQuery, out TQueryHandler> where TQuery : IQuery<TResponse> where TQueryHandler : IQueryHandler<TQuery, TResponse>
    {
        TQueryHandler Create(TQuery query);
    }
}