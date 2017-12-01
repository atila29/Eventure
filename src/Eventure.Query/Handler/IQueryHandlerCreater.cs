namespace Eventure.Query.Handler
{
    public interface IQueryHandlerCreater<out TResponse,in TQuery, out TQueryHandler> where TQuery : IQuery<TResponse> where TQueryHandler : IQueryHandler<TQuery, TResponse>
    {
        TQueryHandler Create(TQuery query);
    }
}