using System;
using Eventure.Domain.Aggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Eventure.Domain.Extensions
{
    public static class RegisterAggregateFactoryExtension
    {
        public static void RegisterAggregateFactory<TAggregate, TCreater>(this IServiceCollection serviceCollection) 
            where TCreater : class, IAggregateRootCreater<TAggregate, Guid> 
            where TAggregate : IAggregateRoot
        {
            serviceCollection.RegisterAggregateFactory<TAggregate, Guid, TCreater>();
        }
        
        public static void RegisterAggregateFactory<TAggregate, TAggregateId, TCreater>
            (this IServiceCollection serviceCollection) 
            where TAggregate : IAggregateRoot<TAggregateId> 
            where TCreater : class, IAggregateRootCreater<TAggregate, TAggregateId> 
            where TAggregateId : IComparable, IComparable<TAggregateId>, IEquatable<TAggregateId>
        {
            serviceCollection.AddTransient<IAggregateRootCreater<TAggregate, TAggregateId>, TCreater>();
        }
    }
}