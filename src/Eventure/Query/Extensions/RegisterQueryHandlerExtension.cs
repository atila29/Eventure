using Eventure.Query.QueryHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Query.Extensions
{
    public static class RegisterQueryHandlerExtension
    {
        public static void RegisterQuery<TQuery, TQueryHandler, TResult>(this IServiceCollection serviceCollection) 
            where TQuery : IQuery<TResult>
            where TQueryHandler : class, IQueryHandler<TQuery, TResult>
        {
            
            serviceCollection
                .AddTransient<IQueryHandler<TQuery, TResult>, TQueryHandler>();
        }   
    }
}